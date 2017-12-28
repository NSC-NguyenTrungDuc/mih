//
//  ForgotPasswordViewController.h
//  PHR
//
//  Created by SonNV1368 on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRBaseViewController.h"

@interface ForgotPasswordViewController : PHRBaseViewController<UITextFieldDelegate>{
    
}
@property (strong, nonatomic) IBOutlet UIImageView *imageBackground;
@property (strong, nonatomic) IBOutlet UILabel *labelDescription;
@property (strong, nonatomic) IBOutlet UIButton *buttonBack;
@property (strong, nonatomic) IBOutlet UIButton *buttonSent;
@property (strong, nonatomic) IBOutlet UITextField *textFieldMail;

- (IBAction)pressButtonBack:(id)sender;
- (IBAction)pressButtonReset:(id)sender;

@end
