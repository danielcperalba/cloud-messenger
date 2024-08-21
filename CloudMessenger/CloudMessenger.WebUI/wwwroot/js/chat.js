"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    li.className = "message-item";

    var profileCircle = document.createElement("div");
    profileCircle.className = "profile-circle";
    profileCircle.textContent = user.charAt(0).toUpperCase();

    var messageContent = document.createElement("span");
    messageContent.textContent = `${user}: ${message}`;

    li.appendChild(profileCircle);
    li.appendChild(messageContent);

    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});