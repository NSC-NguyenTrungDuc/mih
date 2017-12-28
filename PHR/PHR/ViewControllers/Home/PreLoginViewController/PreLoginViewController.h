//
//  PreLoginViewController.h
//  PHR
//
//  Created by NextopHN on 4/28/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Base2ViewController.h"

@interface PreLoginViewController : Base2ViewController <UIDocumentInteractionControllerDelegate>
@property (weak, nonatomic) IBOutlet UIWebView *preLoginContent;
@property (weak, nonatomic) IBOutlet UIButton *buttonCancel;
@property (weak, nonatomic) IBOutlet UIButton *buttonAgree;
@property (copy, nonatomic) void(^onAgreeComplete)(int mess);
@property (weak, nonatomic) IBOutlet UILabel *labelTitle;
@property (assign, nonatomic) BOOL isLoginFaceBook;
- (IBAction)actionCancel:(id)sender;
- (IBAction)actionAgree:(id)sender;

@end
