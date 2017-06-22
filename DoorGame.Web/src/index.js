import React from 'react';
import ReactDOM from 'react-dom';
import App from './reactsrc';

// Add these imports - Step 1
import { Provider } from 'react-redux';
import { store } from './reduxsrc';

// Wrap existing app in Provider - Step 2
ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('root')
);

$(function () {
    var hub = $.connection.aHub;
    hub.client.hello = function () { console.log("Hello!") };
    hub.client.dispatch = store.dispatch;
    $.connection.hub.start().done(function () {
        hub.server.hello();
    });
});
