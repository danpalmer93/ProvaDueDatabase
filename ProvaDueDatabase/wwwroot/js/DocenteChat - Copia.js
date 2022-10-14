var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/avatarChat", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();

let gruppo = "";
var domanda = "";
var testoRisposta = "";
var idRisposta = 0;
var idFigura = 1;
var idDomanda = 1;
var rispostaLibera = "";
var espressione = 0;


function step(id) {

    if (id <= 2) {
        dammi(idFigura);
        caricoDomanda(idDomanda);
        caricaRisposte(idFigura, idDomanda);

    } else if (id > 2 && id <= 4) {
        dammi(idFigura);
        getRispostaLibera();
    }
}

function getRispostaLibera() {

    document.getElementById("countUno").className = "d-none";
    document.getElementById("tabella_risposte").className = "d-none";
    document.getElementById("domanda-show").textContent = "";
    document.getElementById("risposta-show").textContent = "Risposta Libera";
}

// riceve i messaggi dal signalR
connection.on("ReceiveMessage", function (message, id_figura, countDomanda) {

    if (idFigura != id_figura) {
        idDomanda = 1;
    }
    idFigura = id_figura;
    dammi(idFigura);
    caricaRisposte(idFigura, idDomanda);
})

// si connette al signalR
async function Connetti() {
    connection.start().then(res => {
        selectGroup();
    });
}

//  seleziona la risposta
function Seleziona() {
    var a = document.getElementById("rispostaSelezionata").value;
    document.getElementById("risposta").value = a;
}


// Prendo le immagini    
function getFigures(count) {
    return fetch("https://localhost:44354/api/DocenteApi/" + count, {
        method: 'GET'
    });
}

//Prendo Domanda
async function prendoDomanda(id) {
    const response = await fetch("https://localhost:44354/api/DomandeApi/" + id, {
        method: "GET"
    });
    return response.json();
}

//Prendo Risposte
async function prendoRisposte(idFigura, idDomande) {
    const response = await fetch("https://localhost:44354/api/DocenteApi/" + idFigura + "/" + idDomande, {
        method: 'GET',
    });
    return response.json();
}

async function caricaRisposte(idFigura, idDomande) {

    document.getElementById("box-risposte").className = "col-4";
    document.getElementById("countUno").className = "";
    document.getElementById("tabella_risposte").className = "text-center";


    let risposte = await prendoRisposte(idFigura, idDomande);

    //Seleziono il div dove vengono inserite le select
    let div = document.getElementById("countUno");

    // rimuovo eventuali select create per non duplicare 
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }

    //creo select dove inserire le risposte
    var select = document.createElement("select");
    select.id = "selectTutteRisposte";
    select.className = "form-select";

    // creo il label della select
    var label = document.createElement("label");
    label.className = "text-primary";
    label.textContent = "Tutte le altre Risposte";

    //creo le opzioni con le risposte
    var optionDefault = document.createElement("option");
    optionDefault.value = "";
    optionDefault.selected = "selected";
    optionDefault.hidden = "true";

    //inserisco i tag creati
    select.appendChild(optionDefault);
    document.getElementById("countUno").appendChild(label);
    document.getElementById("countUno").appendChild(select);


    for (let a = 0; a < risposte.length; a++) {

        if (a == 0) {
            document.getElementById("rispostaDefault").textContent = risposte[a]["testoRisposta"];
            document.getElementById("inp-rispostaDefault").value = risposte[a]["id"];
            testoRisposta = risposte[a]["testoRisposta"];
            idRisposta = Number(risposte[a]["id"]);
            document.getElementById("risposta-show").textContent = testoRisposta;
            var black50 = document.getElementsByClassName("text-lg-center");
            for (label of black50) {
                label.className = "text-lg-center text-black-50";
            }
            document.getElementById("rispostaDefault").className = "text-lg-center";

            document.getElementById("btn-" + a).addEventListener("click", function (event) {
                testoRisposta = risposte[a]["testoRisposta"];
                idRisposta = Number(risposte[a]["id"]);
                document.getElementById("risposta-show").textContent = testoRisposta;
                var black50 = document.getElementsByClassName("text-lg-center");
                for (label of black50) {
                    label.className = "text-lg-center text-black-50";
                }
                document.getElementById("rispostaDefault").className = "text-lg-center";
            });
        }
        if (a > 0 && a < 5) {

            document.getElementById("labelRisposta" + a).textContent = risposte[a]["testoRisposta"];
            document.getElementById("rispostaSelezionata" + a).value = risposte[a]["id"];
            document.getElementById("btn-" + a).addEventListener("click", function (event) {
                testoRisposta = risposte[a]["testoRisposta"];
                idRisposta = Number(risposte[a]["id"]);
                document.getElementById("risposta-show").textContent = testoRisposta;
                var black50 = document.getElementsByClassName("text-lg-center");
                for (label of black50) {
                    label.className = "text-lg-center text-black-50";
                }
                document.getElementById("labelRisposta" + a).className = "text-lg-center";
            });
        }

        if (a >= 5) {

            var option = document.createElement("option");
            option.text = risposte[a]["testoRisposta"];
            document.getElementById("selectTutteRisposte").appendChild(option);

            option.addEventListener("click", function (event) {
                testoRisposta = risposte[a]["testoRisposta"];
                idRisposta = Number(risposte[a]["id"]);
                document.getElementById("risposta-show").textContent = testoRisposta;
                var black50 = document.getElementsByClassName("text-lg-center");
                for (label of black50) {
                    label.className = "text-lg-center text-black-50";
                }
            });
        }
    }
}

async function dammi(idFigura) {

    let pictures = document.getElementById("imgFigura");

    const response = await getFigures(idFigura);
    let dati = await response.json();
    document.getElementById("div-SelezioneGruppo").className = "d-none";

    for (let a of dati) {
        pictures.src = "data: image/jpeg; base64," + a["immagine"];
        pictures.className = "w-100";
        pictures.style = "border: solid 1px ghostwhite; border-radius:10px 10px";
    }

}

// prende gli utenti connessi
async function getUser() {
    const response = await fetch("https://localhost:44354/api/Utente/", {
        method: "GET"
    })
    return response.json();
}


// seleziona il gruppo degli utenti connessi
async function selectGroup() {

    let gruppi = await getUser();

    for (let a of gruppi) {
        let option = document.createElement("option");
        document.getElementById("selezioneGruppi").appendChild(option);
        option.value = a["id"];
        option.id = a["id"];
        option.textContent = a["id"];
    }
}

// si aggiunge al gruppo degli utenti connessi 
document.getElementById("seleziona").addEventListener("click", function (event) {
    gruppo = document.getElementById("selezioneGruppi").value
    connection.invoke("AddToGroup", gruppo);
    if (this.isConnected) {
        dammi(idFigura);
        caricoDomanda(idDomanda);
        caricaRisposte(idFigura, idDomanda);
    }
});

// invio messaggio all'avatar
document.getElementById("rispondi").addEventListener("click", function (event) {
    rispostaLibera = document.getElementById("rispostaLibera").value;

    if (idDomanda < 4) {
        if (rispostaLibera == "" || rispostaLibera == undefined) {

            if (idDomanda > 2) {
                alert("inserisci una risposta");
            } else {
                connection.invoke("SendMessageToGroup", gruppo, String(idRisposta), "", Number(idDomanda), "", espressione);
                idDomanda++;
            }

        } else if (rispostaLibera != "" || rispostaLibera != undefined) {
            connection.invoke("SendMessageToGroup", gruppo, "", "", Number(idDomanda), rispostaLibera, espressione);
            idDomanda++;
        }

        document.getElementById("rispostaLibera").value = "";
        espressione = 0;
        step(idDomanda);

    } else if (idDomanda == 4) {

        if (rispostaLibera == "" || rispostaLibera == undefined) {
            alert("inserisci una risposta");
        } else {
            connection.invoke("SendMessageToGroup", gruppo, "", "", Number(idDomanda), rispostaLibera, espressione);
        }

        idFigura++;
        idDomanda = 1;
        step(idDomanda);
        document.getElementById("rispostaLibera").value = "";
        espressione = 0;
        restartOrNextStep();
        /*alert("cambiare Figura");*/
    }

});


document.getElementById("restart").addEventListener("click", function (event) {
    idFigura = 1;
    idDomanda = 1;
    dammi(idFigura);
    caricoDomanda(idDomanda);
    caricaRisposte(idFigura, idDomanda);
    restartOrNextStep();
});

function restartOrNextStep() {
    idDomanda = 1;
    connection.invoke("SendRestartMessage", gruppo, String(idFigura));
    step(idDomanda);
}


//visualizzo la domanda
async function caricoDomanda(idDomanda) {
    let domanda = await prendoDomanda(idDomanda);
    document.getElementById("domanda-show").textContent = domanda["testoDomanda"];
    document.getElementById("box-domanda-risposta").className = "d-flex row w-100 "
}


function iconFocus(id) {
    document.getElementById(id).className = "focus";
    document.getElementById(id).parentElement.className = "d-grid col-2 emojiSelected"
}

function iconNormal(id) {
    document.getElementById(id).className = "";

    var child = document.getElementById("emoji").children;
    for (let c of child) {
        c.className = "d-grid col-2 emojiNotSelected";
    }

    document.getElementById(espressione).parentElement.className = "d-grid col-2 emojiSelected";
}

function setEspressione(idEspressione) {
    espressione = Number(idEspressione);


}

function sendMessage(risposta) {
    connection.invoke("SendMessageToGroup", gruppo, "", "", Number(idDomanda), risposta, espressione);
}

