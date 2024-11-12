// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var compliments = ["Du har en fantastisk evne til at forklare komplekse ting, så de bliver nemme at forstå.",
"Din passion for undervisning inspirerer mig virkelig til at lære og udvikle mig.",
"Jeg sætter pris på, at du tager dig tid til at lytte og svare på alle vores spørgsmål.",
"Din tålmodighed og forståelse gør undervisningen til en positiv oplevelse.",
"Du skaber et trygt og støttende læringsmiljø, hvor alle føler sig velkomne.",
"Jeg er imponeret over, hvor engageret du er i vores udvikling – det betyder meget.",
"Din entusiasme smitter, og det gør undervisningen både sjov og motiverende.",
"Det er tydeligt, hvor meget energi og arbejde du lægger i din undervisning.",
"Jeg beundrer din evne til at gøre undervisningen relevant og interessant.",
"Din tro på, at vi kan klare opgaverne, giver mig selvtillid til at gøre mit bedste."];

function Compliment() {
    document.getElementById("ComplimentText").innerHTML = compliments[Random()];
    document.getElementById("ComplimentText").style.backgroundColor = "red";
    document.getElementById("ComplimentText").style.color = "Yellow";
}

function Random() {
    return Math.floor(Math.random() * 10);
}

function Fact() {
    const forbindelse = new XMLHttpRequest();
    forbindelse.onload = function () {
        document.getElementById("Fact").innerHTML = this.responseText;
    }
    forbindelse.open("GET", "js/factfil.txt");
    forbindelse.send();

}

