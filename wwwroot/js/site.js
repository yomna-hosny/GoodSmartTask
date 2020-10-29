// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/Hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(start);

connection.on("NewStudent", (student) => {
    let i = document.getElementById("tbody")
    let templet = `

           <tr>
                <td>${student.name}</td>
                <td>${student.mail}</td>
                <td>${student.address}</td>
                <td>${student.age}</td>
                <td>${student.phone}</td>
                <td>${student.gender}</td>
                <td>${student.city}</td>
            </tr>
`
    i.insertAdjacentHTML("beforeend", templet)
});

// Start the connection.
start();