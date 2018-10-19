// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Emulates C# s.Format(...)
// First, checks if it isn't implemented yet.
// sample: template.format('x','y');
if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] !== 'undefined'
                ? args[number]
                : match;
        });
    };
}

// Show json idented
function logObject(object) {
    console.log('\nJSON:\n' + JSON.stringify(object, null, 2))
}

// shortcut for this...
function log(message) {
    console.log('\n' + message);
}

// usage
//=> 3..padLeft() => '03'
//=> 3..padLeft(100,'-') => '--3' 
Number.prototype.padLeft = function (base, chr) {
    var len = (String(base || 10).length - String(this).length) + 1;
    return len > 0 ? new Array(len).join(chr || '0') + this : this;
}


function formatDateTime(d) {
    var result = [(d.getMonth() + 1).padLeft(), d.getDate().padLeft(), d.getFullYear().toString().substr(-2)].join('/') +
        ' ' +
        [d.getHours().padLeft(), d.getMinutes().padLeft(), d.getSeconds().padLeft()].join(':');
    return result;
}

function getLocalTime() {
    var time = new Date();
    var result =
        ('0' + time.getHours()).slice(-2) + ':' +
        ('0' + time.getMinutes()).slice(-2) + ':' +
        ('0' + time.getSeconds()).slice(-2);
    return result;
}

