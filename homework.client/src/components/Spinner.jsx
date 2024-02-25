import PropTypes from "prop-types";
function Spinner(props) {
    const loadingText = props.loadingText;
    return (
        <div className="spinner-container">
            <div className="spinner-border" role="status"></div>
            <span className="spinner-text">{loadingText}</span>
        </div>
    )
}

Spinner.propTypes = {
    loadingText: PropTypes.string,
};

export default Spinner;