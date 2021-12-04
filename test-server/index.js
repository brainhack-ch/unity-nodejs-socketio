var express = require('express');
var path = require('path');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);

var publicPath = path.resolve(__dirname);
app.use(express.static(publicPath));

app.get('/', function(req, res){
    res.sendFile('/index.html', { root: publicPath });
});

var userId = 0;
io.on('connection', function(socket){
  socket.userId = userId ++;
  console.log('a user connected, user id: ' + socket.userId);

  socket.on('chat', function(msg){
    console.log('message from user#' + socket.userId + ": " + msg);
    io.emit('chat', {
      id: socket.userId,
      msg: msg
    });
  });
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});