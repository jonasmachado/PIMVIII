/*
 * Localized default methods for the jQuery validation plugin.
 * Locale: PT_BR
 */
jQuery.extend(jQuery.validator.methods, {
    date: function (value, element) {
        return this.optional(element) || /^([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/([1-2]\d{3})(?:(?:\s([0-1]\d|[2][0-3])\:([0-5]\d)(?::([0-5]\d))?)?)$/.test(value);
    },
    number: function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
    }    
});