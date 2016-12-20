var g = G$('Mayank','Aggarwal');
g.greet().setLang('es').greet(true);

$("#Login").click(function() {
    var loginGtr = G$('John','Doe');
    $('#logindiv').hide();
    
    loginGtr.setLang($("#lang").val()).greetBySelector('#greeting',true).log();
    //g.setLang($("#lang").val()).greetBySelector($("#greeting"));
});