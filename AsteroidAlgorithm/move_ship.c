#include "asteroids.h"

struct ship_action move_ship(int field[][FIELD_WIDTH], void *ship_state){

    int shipPosition = 0;
    int lowerFlag = 0;
    int middleFlag = 0;
    int upperFlag = 0;
    
    int action = 0;
    
    //Find shipPosition
    for(int i = 0; i < FIELD_HEIGHT; i++){
        if(field[i][0] == 2){
            shipPosition = i;
        }
    }
    
    //Check if there is asteroid in front of ship
    if(field[shipPosition][SHIP_WIDTH] == 1){
        middleFlag = 1;
    }
    
    //Check for asteroid above and below ship
    for(int i = 0; i < SHIP_WIDTH; i++){
        //Check above
        if(field[shipPosition - 1][i] == 1){
            upperFlag++;
        }
        //Check below
        if(field[shipPosition + 1][i] == 1){
            lowerFlag++;
        }
    }
    
    //Variables for measuring longest path
    int upperCount = 0;
    int lowerCount = 0;
    int middleCount = 0;
    
    //find longest path for upper
    for(int i = 0; i < FIELD_WIDTH; i++){
        if(field[shipPosition - 1][i] == 1){
            upperCount = i;
            break;
        }   
    }
    //find longest path for middle
    for(int i = 0; i < FIELD_WIDTH; i++){
        if(field[shipPosition][i] == 1){
            middleCount = i;
            break;
        }    
    }
    //find longest path for lower
    for(int i = 0; i < FIELD_WIDTH; i++){
        if(field[shipPosition + 1][i] == 1){
            lowerCount = i;
            break;
        }    
    }
    
    //If counts for longest path == 0 set to max value
    if(lowerCount == 0){
        lowerCount = 40;
    }
    if(middleCount == 0){
        middleCount = 40;
    }
    if(upperCount == 0){
        upperCount = 40;
    }
    
    
    //Variables for checking if tunnel exists
    int upperTunnelCheck = 0;
    int lowerTunnelCheck = 0;
    int midTunnelFlag = 0;
    
    //Check if tunnel exists in ships path
    if(middleCount != 40){
        for(int i = 0; i <= SHIP_WIDTH; i++){
            if(field[shipPosition + 1][middleCount - i] == 1){
                lowerTunnelCheck++;
            }
            if(field[shipPosition - 1][middleCount - i] == 1){
                upperTunnelCheck++;
            }
        }
    }
    
    //Increment midTunnelFlag if tunnel exists
    if(upperTunnelCheck >= 1 && lowerTunnelCheck >= 1 || lowerTunnelCheck >= 1 && shipPosition== 0 || upperTunnelCheck >= 1 && shipPosition == 19){
        midTunnelFlag++;
    }
    
    //Determine action
    if(upperCount > middleCount && upperCount > lowerCount && upperFlag == 0 && shipPosition != 0){
        action = -1;
    }
    else if(lowerCount > upperCount && lowerCount > middleCount && lowerFlag == 0 && shipPosition != 0){
        action = 1;
    }
    else{
        //If upperFlag and middleFlag >= 1 go down
        if(upperFlag >= 1 && middleFlag >= 1){
            action = 1;
        }
        //If lowerFlag and middleFlag >= 1 go up
        else if(lowerFlag >= 1 && middleFlag >= 1){
            action = -1;
        }
        //If at the top of matrix and midTunnelFlag >= 1 and lowerFlag == 0 go down
        else if(shipPosition == 0 && midTunnelFlag >= 1 && lowerFlag == 0){
            action = 1;
        }
        //If at the bottom of matrix and midTunnelFlag >= 1 and upperFlag == 0 go up
        else if(shipPosition == 19 && midTunnelFlag >= 1 && upperFlag == 0){
            action = -1;
        }
        //If asteroid found in front of ship go up or if tunnel is found go up
        else if((lowerFlag == 0 && upperFlag == 0 && middleFlag == 1) || (midTunnelFlag == 1 && upperFlag == 0 && lowerFlag == 0)){
            action = -1;
        }
        //Default to 0
        else{
            action = 0;
        }
    }
    
    //If tunnel found at top of matrix go down
    if(shipPosition == 0 && lowerFlag == 0 && middleCount < lowerCount){
        action = 1;
    }
    //If tunnel found at bottom of matrix go up
    if(shipPosition == 19 && upperFlag == 0 && middleCount < upperCount){
        action = 1;
    }
    
    //Return struct
    struct ship_action ret;
    ret.move = action;
    ret.state = 0;
    return ret;

}
