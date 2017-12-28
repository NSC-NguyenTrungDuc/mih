//
//  CustomNavigationBar.h
//  PHR
//
//  Created by Luong Le Hoang on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef void(^NavBarAction)();

@interface CustomNavigationBar : UIView{
    
}
@property (weak, nonatomic) IBOutlet UIButton *btnBack;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet UIButton *buttonTitle;
@property (weak, nonatomic) IBOutlet UIButton *btnMenuRight;

@property (strong, nonatomic) UIImageView *imageAvatar;

@property (nonatomic, strong) UILabel *labelTitle;
@property (nonatomic, strong) UILabel *labelMenuRight;
@property (nonatomic, strong) UIImageView *imageFamily;
@property (nonatomic, assign) PHRGroupType type;

@property (nonatomic, copy) NavBarAction actionSlideMenu;
@property (nonatomic, copy) NavBarAction actionRight; // Open Family list / Baby list
@property (nonatomic, copy) NavBarAction actionEditProfile;
@property (nonatomic, copy) NavBarAction actionChangeAvatar;
@property (nonatomic, copy) NavBarAction actionBack;

- (IBAction)actionHome:(id)sender;
- (IBAction)actionMenu:(id)sender;
- (IBAction)actionFamily:(id)sender;
- (IBAction)actionChangeAvatar:(id)sender;
- (IBAction)actionBack:(id)sender;

- (void)reloadView;

@end
