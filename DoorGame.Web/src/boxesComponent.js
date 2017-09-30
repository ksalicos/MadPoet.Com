import React, { Component } from 'react';
import { connect } from 'react-redux';
import { initializeHub, hub } from './hub';

export class BoxesComponent extends Component {
    render() {
        var boxes = this.props.boxes;
        var colors = this.props.boxes.colors;

        if (!boxes.cols) {
            return (null)
        }

        if (colors.length % boxes.cols !== 0) {            
            console.log("Array length invalid", boxes.cols, colors);
            return (<div>Error</div>)
        }

        var rows = [];
        for (var i = 0; i < colors.length; i += boxes.cols) {
            var row = [];
            for (var j = 0; j < boxes.cols; j++) {
                row[j] = colors[i + j];
            }
            rows.push(Row(row, i));
        }

        return (
            <div className="container-fluid">
                {rows}
            </div>
        );
    }
};

function Row(colors, idx) {
    var cells = [];
    for (var i = 0; i < colors.length; i++) {
        cells.push(
            <div className="col-xs-1" key={'C' + i + 'R' + idx}>
                <Box color={colors[i]} />
            </div>
        );
    }
    return (
        <div className="row no-gutters" key={'R' + idx}>
            {cells}
        </div>)
}

function Box(props) {
    return (<div className="resizable" style={{ backgroundColor: props.color }}>&nbsp;</div>)
}

const mapStateToProps = (state, ownProps) =>
    ({
        boxes: state.boxes,
    });

const mapDispatchToProps = {
};

const BoxesContainer =
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(BoxesComponent);

export default BoxesContainer;  