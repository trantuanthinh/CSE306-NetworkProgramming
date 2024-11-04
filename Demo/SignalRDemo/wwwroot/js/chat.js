var connection = new signalR.HubConnectionBuilder().withUrl("chatHub").build();

document.getElementById("sendButton").disabled = true;
conection.start().then(function () {
    document.getElementByID("sendButton").disabled = false;
}) catch (function(err) {
    return console.error(err.toString());
})

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    })
    event.preventDefault();
})

connection.on("ReceiveMessage",(function(user, message){
    var li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messageList").appendChild(li);
})