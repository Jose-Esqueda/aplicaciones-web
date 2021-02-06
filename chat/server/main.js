const { Socket } = require('dgram');
var express = require('express');
const { stderr } = require('process');
const { measureMemory } = require('vm');
var app = express();
var server = require("http").Server(app);
var io = require("socket.io")(server);

var messages = [
    {
        id:1,
        text:'Hello...',
        author:'Jose E'
    },
];



app.use(express.static('public'));

io.on(
    'connection',(socket) => {
        console.log('Someone has connected');

        socket,emit('messages',messages);
        socket.on('new-message',(data)=>{
            messages.push(data)
            console.log(data);
            console.log(messages);

            io.sockets.emit('messages',messages);
        });
    }
);

//Ruta hacia el root
app.get('/',(req, res) => 
    {res.status(200).send('This is the root...')
});
//Ruta hacia hello
app.get('/hello',(req, res) => 
    {res.status(200).send('Hello world..')
});

server.listen(8080, () => {
    console.log("Server is running in http://localhost:8080")
});