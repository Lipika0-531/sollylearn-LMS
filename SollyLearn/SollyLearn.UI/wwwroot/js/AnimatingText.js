// Typing animation
const text = "Stay eager, stay curious, and embrace the joy of learning.";
let index = 0;

function typeWriter() {
    if (index < text.length) {
        document.getElementById("typing-text").innerHTML += text.charAt(index);
        index++;
        setTimeout(typeWriter, 50);
    }
}

typeWriter();

