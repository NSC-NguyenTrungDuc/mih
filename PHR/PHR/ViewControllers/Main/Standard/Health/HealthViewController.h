//
//  HealthViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 10/1/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "DALinedTextView.h"

@interface HealthViewController : Base2ViewController <UITextViewDelegate, UITextFieldDelegate>{
    
}
@property (weak, nonatomic) IBOutlet PHRDateTimeView *datetimeView;
@property (weak, nonatomic) IBOutlet DALinedTextView *noteTextView;
@property (weak, nonatomic) IBOutlet PHRTextField *txtPercentage;

/* ------------------------ Custom Textfields ------------------------ */
@property (weak, nonatomic) IBOutlet PHRTextField *txtHeight;
@property (weak, nonatomic) IBOutlet PHRTextField *txtWeight;
@property (weak, nonatomic) IBOutlet PHRTextField *txtWaistline;

@property (weak, nonatomic) IBOutlet PHRTextField *txtChestSize;
@property (weak, nonatomic) IBOutlet PHRTextField *txtLowBlood;
@property (weak, nonatomic) IBOutlet PHRTextField *txtHighBlood;

@property (strong, nonatomic) NSString *standardHealthId;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundImage;
@property (copy,nonatomic) void(^addHealthCallBack)(HealthItem *type);

@end
