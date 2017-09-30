import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { store } from './store';
import App from './reactsrc';

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
    setBoxSize();
});

function getStyleRule(name) {
    //thanks DaveInMaine
    for (var i = 0; i < document.styleSheets.length; i++) {
        var ix, sheet = document.styleSheets[i];
        for (ix = 0; ix < sheet.cssRules.length; ix++) {
            if (sheet.cssRules[ix].selectorText === name)
                return sheet.cssRules[ix].style;
        }
    }
    return null;
}

$(window).resize(setBoxSize);

function setBoxSize() {
    var boxHeight = $(window).height() / 10;
    var rule = getStyleRule('.resizable');
    if (rule) {
        rule.height = boxHeight + "px";
    }
}