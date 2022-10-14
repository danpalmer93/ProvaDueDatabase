// Connessione a Signal-R
var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/avatarChat", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();

var figura = 1;
var idDomanda = 1;

connection.on("Join", function () {
    let snack = document.getElementById("snack-bar");
    snack.className = "snack-show";
    setTimeout(function () { snack.className = snack.className.replace("-show", ""); }, 3000);
});


connection.on("ReceiveMessage", function (message, figura, opzione, rispostaLibera, inpEspressione) {
    document.getElementById("numeroDomandadellaFigura").textContent = opzione+1;
    if (message == "") {
        speakFunction(rispostaLibera, inpEspressione);
    } else if (message != "") {
        mandoRisposta(message, inpEspressione);
    }
});

connection.on("RestartMessage", function (idFigura) {
    idDomanda = 1;
    document.getElementById("numeroDomandadellaFigura").textContent = idDomanda;
    document.getElementById(figura).className = " w-100 h-100 d-none";
    figura = idFigura;
    document.getElementById(figura).className = " w-100 h-100 ";
});

async function mandoRisposta(message, inpEspressione) {
    let jsonRisposta = await get("https://localhost:44354/api/RispostaApi/" + message);
    var testoRisposta = jsonRisposta["testoRisposta"];
    speakFunction(testoRisposta, inpEspressione);
}


async function get(url) {
    const response = await fetch(url, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    });
    return response.json();
}


//async function prendoRisposta(message) {

//    const response = await fetch("https://localhost:44354/api/RispostaApi/" + message, {
//        method: "GET",
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        }
//    });

//    return response.json();
//}

connection.onclose(function(){
    let nome = sessionStorage.getItem("nome");
    let cognome = sessionStorage.getItem("cognome");
    let id = sessionStorage.getItem("id");
    remove(id, nome, cognome);
});


// connetto al SIGNAL-R e aggiungo L'id Sessione
 async function Connetti() {
     connection.start().then(() => {
         let nome = sessionStorage.getItem("nome");
         let cognome = sessionStorage.getItem("cognome");
         let date = new Date().toLocaleString();
         let id = nome + " " + cognome + " " + date;
             sessionStorage.setItem("id", id);
         insert(id, nome, cognome);
         connection.invoke("AddToGroup", id);
         caricoFigure();
         
     });
}

async function caricoFigure() {

    let listaFigure = await getFigure();
    
    for (let a = 0; a < listaFigure.length; a++) {

        let img = document.createElement("img");
        img.id = listaFigure[a]["id"];
        img.src = "data: image/jpeg; base64," + listaFigure[a]["immagine"];
        img.style = " border: solid 1px ghostwhite; border-radius:10px 10px";

        a == 0 ? img.className = " w-100 h-100" : img.className = "w-100 h-100 d-none";

        document.getElementById("box-figure").appendChild(img);
    }

}

//Prendo  le figure
 async function getFigure() {
    const response = await fetch("https://localhost:44354/api/FigureApi/", {
        method: 'GET'
    });
     return response.json();
}


//Aggiungo Utente all'inizio della connessione
function insert(id, nome, cognome) {

    return fetch("https://localhost:44354/api/Utente", {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "Id": id,
            "Nome": nome,
            "Cognome": cognome
        })
    });
}

// Rimuovo id Utente alla chiusura della pagina
function remove(id, nome, cognome) {
    return fetch("https://localhost:44354/api/Utente", {
        method: "DELETE",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "Id": id,
            "Nome": nome,
            "Cognome": cognome
        })
    });
}

// Funzione per l'avatar
 function speakFunction(message, inpEspressione) {

    
    var espressioni = ["None","ClosedSmile", "OpenSmile", "Sad", "Angry", "Fear", "Disgust", "Surprise", "Thinking", "Blush","Scream"];
     var espressione = espressioni[inpEspressione];
    var durata = 4;
    var ampiezza = 0.7;


    $('#flash-speck-area').removeClass('flash-speck-error');
    var speakingTxt = message;
    if (speakingTxt == '' || speakingTxt == undefined) {
        speakingTxt = "Benvenuto";
        espressione = "Angry";
        durata = 3;
        ampiezza = 0.8;
    } else if (speakingTxt == '') {
        $('#flash-speck-area').addClass('flash-speck-error');
        setTimeout(function () {
            $('#flash-speck-area').removeClass('flash-speck-error');
        }, 2000);
        return false;
    }

    var languageBtn = 7;
    var voiceBtn = 1;
    var engineID = 7;
    var effectBtn = $('#effectBtn').attr('data-val');
    var levelBtn = $('#levelBtn').attr('data-val');
    console.log('speakingTxt', speakingTxt);
    console.log('voiceBtn', voiceBtn);
    console.log('languageBtn', languageBtn);
    console.log('engineID', engineID);

    setEspressione(espressione, ampiezza, durata);

    if (effectBtn == '' || levelBtn == '') {
        sayText(speakingTxt, voiceBtn, languageBtn, engineID, 0, 0);
    } else {
        sayText(speakingTxt, voiceBtn, languageBtn, engineID, effectBtn, levelBtn);
    }

}

function setEspressione(espressione, ampiezza, durata) {
    if (ampiezza > 0.8) {

        setFacialExpression(espressione, "0.8", durata);
    } else {
        setFacialExpression(espressione, ampiezza, durata);
    }
}


// funzione per dire benvenuto allo studente in base al nome della sezione
async function welcome() {
    var languageBtn = 7;
    var voiceBtn = 1;
    var engineID = 7;
    var speakingTxt = "Benvenuti";  
    sayText(speakingTxt, voiceBtn, languageBtn, engineID, 0, 0);
}



    
document.getElementById("figuraIndietro").className = "d-none";
document.getElementById("numeroDomandadellaFigura").textContent = idDomanda;

document.getElementById("figuraAvanti").addEventListener("click", function (event) {
        
        if (figura < 10) {
            var inputFigura = figura;

            document.getElementById(inputFigura).className = " w-100 h-100 d-none";
            figura++;
            document.getElementById(figura).className = "w-100 h-100";
            sendMessage(figura);
            document.getElementById("figuraIndietro").className = " ";

            if (figura == 10) {
                document.getElementById("figuraAvanti").className = "d-none";
                sendMessage(figura);
            }
        }
        
        
        
    });

    document.getElementById("figuraIndietro").addEventListener("click", function (event) {
        if (figura > 1) {
            var inputFigura = figura;

            document.getElementById(inputFigura).className = " w-100 h-100 d-none";
            figura--;
            document.getElementById(figura).className = "w-100 h-100";
            sendMessage(figura);
            document.getElementById("figuraAvanti").className = "";
            if (figura == 1) {
                document.getElementById("figuraIndietro").className = "d-none";
                sendMessage(figura);
            }
        }
    });


function sendMessage(figura) {
    connection.invoke("SendMessageToGroup", sessionStorage.getItem("id"), "", String(figura),0, 0);
}



