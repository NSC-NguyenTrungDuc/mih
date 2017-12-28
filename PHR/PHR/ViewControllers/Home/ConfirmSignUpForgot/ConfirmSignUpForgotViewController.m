//
//  ConfirmSignUpForgotViewController.m
//  PHR
//
//  Created by SonNV1368 on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "ConfirmSignUpForgotViewController.h"
#import "SignInViewController.h"

@interface ConfirmSignUpForgotViewController (){
    
}
@property (weak, nonatomic) IBOutlet UIImageView *imageMail;
@property (weak, nonatomic) IBOutlet UIImageView *imageChangePass;
@property (strong, nonatomic) NSString *messageLabel;
@property (assign, nonatomic) ConfirmType type;

@end

@implementation ConfirmSignUpForgotViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupUI];
    [self setupStatusBar];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)setupUI{
    UIImage *newImg = [UIImage imageNamed:@"BGHome"];
    self.imageBackground.image = [newImg applyLightEffect];
    // Message
    [self.labelMessage setText:_messageLabel];
    // Done localized
    [self.buttonDone setTitle:kLocalizedString(kDone) forState:UIControlStateNormal];
  
  
  _imageChangePass.hidden = YES;
  _imageMail.hidden = YES;
  
  if (_type == ConfirmTypeChangePassword) {
    _imageChangePass.hidden = NO;
    //  _imageMail.hidden = YES;
    _labelMessage.textAlignment = NSTextAlignmentCenter;
    _labelMessage.font = [FontUtils aileronBoldWithSize:16.0];
  }else{
    //   _imageChangePass.hidden = YES;
    _imageMail.hidden = NO;
    _labelMessage.textAlignment = NSTextAlignmentLeft;
    _labelMessage.font = [FontUtils aileronRegularWithSize:13.0];
  }
  
}

- (void)setupType:(ConfirmType)type andNoticeMessage:(NSString*)notice{
    self.type = type;
    self.messageLabel = notice;
}

#pragma mark - UI Actions

- (IBAction)actionDone:(id)sender {
    if (self.done) {
        self.done();
        return;
    }
    
    // Comeback to Home
    NSInteger count = self.navigationController.viewControllers.count;
    for (NSInteger i = count - 1; i >= 0; i--) {
        UIViewController *controller = self.navigationController.viewControllers[i];
        if ([controller isMemberOfClass:[SignInViewController class]]) {
            [self.navigationController popToViewController:controller animated:YES];
            return;
        }
    }
    
    // Create new
    SignInViewController *controller = [[SignInViewController alloc] initWithNibName:NSStringFromClass([SignInViewController class]) bundle:nil];
    [self.navigationController pushViewController:controller animated:YES];
    
    // Remove other view controller
    NSMutableArray *controllers = [NSMutableArray arrayWithArray:self.navigationController.viewControllers];
    //TungNT i>0 not >=0 keep last viewcontroller (home controller)
    for (NSInteger i = count - 1; i > 0; i--) {
        UIViewController *controller = self.navigationController.viewControllers[i];
        if (![controller isMemberOfClass:[SignInViewController class]]) {
            [controllers removeObject:controller];
        }
    }
    self.navigationController.viewControllers = controllers;
}

@end
