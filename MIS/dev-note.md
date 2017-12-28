
    /**
     * Please add following code to jQuery step libs
     * Reset state
     * @method reset
     * @returns {Boolean}
     */
    $.fn.steps.reset = function () {
        var wizard = this,
            options = getOptions(this),
            state = getState(this);

        return goToStep(wizard, options, state, 0);
    };