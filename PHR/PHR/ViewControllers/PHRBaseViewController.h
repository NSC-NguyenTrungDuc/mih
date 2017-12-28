//
//  PHRBaseViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 10/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Base2NavigationBar.h"
#import "Base2NavigationBarRightIcon.h"

@interface PHRBaseViewController : UIViewController {
    
}
@property (nonatomic, strong) Base2NavigationBar *navBar;
@property (nonatomic, strong) Base2NavigationBarRightIcon *navBarRightIcon;
- (void)setupStatusBar;
- (UIButton*)createButtonHeaderWithTitle:(NSString *)title;
- (void)handleLoginSuccess;
- (void)requestLoginWithEmail:(NSString*)email password:(NSString*)password;
- (void)requestLoginWithFacebook:(NSString*)token isAutologin:(BOOL)isAutoLogin;
- (void)showPreLoginFacebook:(NSString*)token;
- (void)setupNavigationBarTitle:(NSString *)title titleIcon:(NSString *)titleIcon rightItem:(NSString *)rightItem;
- (void)setupNavigationBarForSignInTitle:(NSString *)title;

@end
