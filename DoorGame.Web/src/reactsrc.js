import React, { Component } from 'react';
import { connect } from 'react-redux';
import { initializeHub, hub } from './hub';
import BoxesComponent from './boxesComponent';

//import {
//    //activateGeod,
//    //closeGeod,
//    } from './reduxsrc';

// App.js
export class App extends Component {
    componentDidMount() {
        initializeHub();
    };

    render() {
        return (
            <div>
                <BoxesComponent />
            </div>
        );
    };
}

// AppContainer.js
const mapStateToProps = (state, ownProps) => ({
    colors: state.colors,
});

const mapDispatchToProps = {
    //activateGeod,
    //closeGeod,
};

const AppContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(App);

export default AppContainer;  