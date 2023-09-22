let username = null;
let isLoggedIn = false;
let userID = null;

class LoginManager {

    static setUserID(userIDParam){
        userID = userIDParam;
    }
    static getUserID() {
        return userID;
    }

    static setUsername(usernameParam){
        username = usernameParam;
    }
    static getUsername() {
        return username;
    }

    static getLoginStatus(){
        return isLoggedIn;
    }

    static login(){
        isLoggedIn = true;
    }

    static logout(){
        isLoggedIn = false;
    }
}


module.exports.LoginManager = LoginManager;