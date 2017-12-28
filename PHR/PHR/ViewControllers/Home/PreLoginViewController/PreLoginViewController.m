//
//  PreLoginViewController.m
//  PHR
//
//  Created by NextopHN on 4/28/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PreLoginViewController.h"

@interface PreLoginViewController ()

@end
static NSString *const AGREEMENT_PDF_NAME = @"AGREEMENT_160418";
@implementation PreLoginViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.preLoginContent.layer.borderColor = [PHRUIColor colorFromHex:@"#555555" alpha:1.0].CGColor;
    self.preLoginContent.layer.borderWidth = 1.0;
    self.preLoginContent.layer.backgroundColor = [UIColor clearColor].CGColor;
    
    self.view.backgroundColor = [UIColor whiteColor];
    
    [self.buttonCancel setTitle:kLocalizedString(kCancel) forState:UIControlStateNormal];
    [self.buttonAgree setTitle:kLocalizedString(kAgree) forState:UIControlStateNormal];
    [self.buttonAgree setBackgroundColor:[[UIColor whiteColor]colorWithAlphaComponent:0.2]];
    self.labelTitle.text = kLocalizedString(kAgreement);
    
    self.labelTitle.backgroundColor = [PHRUIColor colorFromHex:@"#ffffff" alpha:0.2];
    self.labelTitle.layer.shadowOffset = CGSizeZero;
    self.labelTitle.layer.shadowRadius = 10;
    self.labelTitle.layer.shadowColor = [[UIColor whiteColor] colorWithAlphaComponent:0.8].CGColor;
    // Add text view to the main view of the view controler
    NSString* plistPath = [[NSBundle mainBundle] pathForResource:AGREEMENT_PDF_NAME ofType:@"html"];
    NSString *html = [NSString stringWithContentsOfFile:plistPath encoding:NSUTF8StringEncoding error:nil];
    [self.preLoginContent loadHTMLString:html baseURL:[NSURL fileURLWithPath:[[NSBundle mainBundle]bundlePath]]];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
 #pragma mark - Navigation
 
 // In a storyboard-based application, you will often want to do a little preparation before navigation
 - (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
 // Get the new view controller using [segue destinationViewController].
 // Pass the selected object to the new view controller.
 }
 */

- (IBAction)actionCancel:(id)sender {
    // LOG OUT
//    [PHRAppDelegate showLoading];
//    [[PHRClient instance] requestLogoutWithCompleted:^(MFResponse *responseObject) {
//        if ([responseObject.status isEqualToString:KEY_SUCCESS]) {
//            [PHRAppDelegate hideLoading];
//            [PHRAppStatus clearAllData];
//            [[NetworkManager sharedManager] deleteSaveData];
//            [PHRAppDelegate switchRootViewControllerWithAnimated:YES];
//        }
//        else {
//            [NSUtils showMessage:responseObject.content withTitle:APP_NAME];
//        }
//        [PHRAppDelegate hideLoading];
//        [self.navigationController popViewControllerAnimated:YES];
//    }];
    // LOG OUT
    // clear session data
    [PHRAppStatus clearAllData];
    // clear email/pass
    [NetworkManager clearSavedFacebookAccessToken];
    [NetworkManager clearSavedPassword];
    [self.navigationController popViewControllerAnimated:YES];
}

- (IBAction)actionAgree:(id)sender {
    //Call API
    if(self.isLoginFaceBook){
        NSLog(@"----> %@", PHRAppStatus.accountId);
        if(PHRAppStatus.accountId && [PHRAppStatus.accountId length] > 0) {
             [self requestChangeStatusAgreement:PHRAppStatus.accountId];
        }
    } else {
        self.onAgreeComplete(1);
    }
}

#pragma mark - Request API Facebook
- (void)requestChangeStatusAgreement:(NSString*) accountId {
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestChangeAgreementStatus:accountId completed:^(id params) {
        [PHRAppDelegate hideLoading];
        if ([PHRClient getStatusFromResponse:params]) {
             self.onAgreeComplete(1);
            NSLog(@"success");
        } else {
            NSLog(@"unsucess");
        }
    } error:^(NSString *error){
        [PHRAppDelegate hideLoading];
    }];
    
}
@end
