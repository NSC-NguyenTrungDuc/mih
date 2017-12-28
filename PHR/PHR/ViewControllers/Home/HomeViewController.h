//
//  HomeViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRBaseViewController.h"
#import "SignInViewController.h"
#import "SignUpViewController.h"

@interface HomeViewController : PHRBaseViewController{
    
}

@property (weak, nonatomic) IBOutlet UIButton *btnRegister;
@property (weak, nonatomic) IBOutlet UIButton *btnSignIn;
@property (weak, nonatomic) IBOutlet UILabel *labelPersonal;
@property (weak, nonatomic) IBOutlet UILabel *labelHealth;
@property (weak, nonatomic) IBOutlet UILabel *labelRecord;
@property (weak, nonatomic) IBOutlet UILabel *labelAProductOf;
@property (weak, nonatomic) IBOutlet UIView *viewPlayer;

- (IBAction)pressBtnRegister:(id)sender;
- (IBAction)pressBtnSignIn:(id)sender;

@end
