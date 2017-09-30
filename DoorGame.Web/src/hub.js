import { store } from './store';

export var hub = null;

export function initializeHub() {
    $.connection.aHub.client.dispatch = receive;
    $.connection.hub.start().done(function () {
        hub = $.connection.aHub.server;
        hub.initialize();
        loop();
    });
};

function receive(data) {
    store.dispatch(action);
}

function loop() {
    var randomColor = "#000000".replace(/0/g, function () { return (~~(Math.random() * 16)).toString(16); });
    var state = store.getState();
    var size = state.boxes.rows * state.boxes.cols;
    var randomBox = Math.floor(Math.random() * size);
    var randomTimeout = Math.floor(Math.random() * 500);
    hub.changeColor(randomBox, randomColor);
    setTimeout(loop, 1000);
}