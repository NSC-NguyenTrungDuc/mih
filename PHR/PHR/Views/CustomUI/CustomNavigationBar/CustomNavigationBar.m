//
//  CustomNavigationBar.m
//  PHR
//
//  Created by Luong Le Hoang on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "CustomNavigationBar.h"
#import <PureLayout/PureLayout.h>

@interface CustomNavigationBar (){
    
}
@property (nonatomic, strong) ProfileStandard *person;

@end

@implementation CustomNavigationBar {
    
}

- (void)awakeFromNib {
    [self.imageBackground setImage:[[UIImage imageNamed:@"header_bg"] stretchableImageWithLeftCapWidth:50 topCapHeight:0]];
    
    // center label
    float avatarSize = self.buttonTitle.frame.size.height - 10;
    
    self.imageAvatar = [[UIImageView alloc] initForAutoLayout];
    self.imageAvatar.layer.cornerRadius = avatarSize/2;
    self.imageAvatar.layer.borderWidth = 1;
    
    self.imageAvatar.layer.borderColor = [UIColor whiteColor].CGColor;
    [self.imageAvatar setClipsToBounds:YES];
    [self.imageAvatar setImage:[UIImage imageNamed:@"Profile_No_Thumb"]];
    [self.buttonTitle addSubview:self.imageAvatar];
    
    [self.imageAvatar autoSetDimension:ALDimensionWidth toSize:avatarSize];
    [self.imageAvatar autoSetDimension:ALDimensionHeight toSize:avatarSize];
    [self.imageAvatar autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:10];
    [self.imageAvatar autoAlignAxisToSuperviewAxis:ALAxisHorizontal];
    
    
    self.labelTitle = [[UILabel alloc] initForAutoLayout];
    [self.labelTitle setFont:[FontUtils aileronRegularWithSize:13]];
    [self.labelTitle setTextColor:[UIColor whiteColor]];
    [self.labelTitle setTextAlignment:NSTextAlignmentLeft];
    
    [self.buttonTitle addSubview:self.labelTitle];
    [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:50.0];
    [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeTop];
    [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    
    // Button right
    self.imageFamily = [[UIImageView alloc] initForAutoLayout];
    [self.imageFamily setImage:[UIImage imageNamed:@"Icon_Family"]];
    [self.imageFamily setContentMode:UIViewContentModeCenter];
    [self.btnMenuRight addSubview:self.imageFamily];
    [self.imageFamily autoAlignAxisToSuperviewAxis:ALAxisVertical];
    [self.imageFamily autoAlignAxisToSuperviewAxis:ALAxisHorizontal];
    [self.imageFamily autoSetDimension:ALDimensionWidth toSize:30];
    [self.imageFamily autoSetDimension:ALDimensionHeight toSize:30];
    [self.imageFamily autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:10.0f];
    
    self.labelMenuRight = [[UILabel alloc] initForAutoLayout];
    [self.labelMenuRight setFont:[FontUtils aileronRegularWithSize:5]];
    [self.labelMenuRight setTextColor:[UIColor whiteColor]];
    [self.labelMenuRight setAdjustsFontSizeToFitWidth:YES];
    
    [self.btnMenuRight addSubview:self.labelMenuRight];
    [self.labelMenuRight autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:1.5f];
    [self.labelMenuRight autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0.5f];
    [self.labelMenuRight autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:1.0f];
    [self.labelMenuRight autoSetDimension:ALDimensionHeight toSize:8];
    
    // Register notification
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleAvatarStandardChanged:) name:kNotifyAvatarStandardChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleAvatarBabyChanged:) name:kNotifyAvatarBabyChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleNavBarProfileStandardActiveChanged:) name:kNotifyProfileStandardActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleNavBarProfileBabyActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
}

- (void)dealloc{
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}


#pragma mark - Setup view
// Setup view
- (void)setType:(PHRGroupType)type {
    _type = type;
    if (type == PHRGroupTypeStandard) {
        [self.imageFamily setImage:[UIImage imageNamed:@"Icon_Family"]];
        [self.labelMenuRight setTextAlignment:NSTextAlignmentCenter];
        [self.labelMenuRight setText:@""]; //kLocalizedString(kFamilyList)];
    }
    else if (type == PHRGroupTypeBaby) {
        [self.imageFamily setImage:[UIImage imageNamed:@"Icon_Family"]];
        [self.labelMenuRight setTextAlignment:NSTextAlignmentRight];
        [self.labelMenuRight setText:@""]; //kLocalizedString(kBabyList)];
    }
    [self reloadView];
}

- (void)reloadView {
    // declare KVO
    if (self.type == PHRGroupTypeStandard) {
        [self reloadView:PHRAppStatus.currentStandard];
    }
    else if (self.type == PHRGroupTypeBaby) {
        [self reloadView:PHRAppStatus.currentBaby];
    }
}

- (void)reloadView:(Profile*)profile {
    DLog(@"PHRAppStatus.profile name = %@", profile ? profile.name : @"DELETED");
    [self.labelTitle setText:profile ? profile.name : @""];
    [self.imageAvatar sd_setImageWithURL:[NSURL URLWithString:profile ? profile.avatar : @""] placeholderImage:[UIImage imageNamed:@"Profile_No_Thumb"] options:SDWebImageRefreshCached];
}

#pragma mark - Handle notification
- (void)handleAvatarStandardChanged:(NSNotification*)notification{
    if (self.type == PHRGroupTypeStandard) {
        [self handleAvatarChanged:PHRAppStatus.currentStandard];
    }
}

- (void)handleAvatarBabyChanged:(NSNotification*)notification{
    if (self.type == PHRGroupTypeBaby) {
        [self handleAvatarChanged:PHRAppStatus.currentBaby];
    }
}

- (void)handleAvatarChanged:(Profile*)profile{
    if (profile) {
        [self reloadView:profile];
    }
}

- (void)handleNavBarProfileStandardActiveChanged:(NSNotification*)notification{
    DLog(@"NavBar %d ==> handleProfileActiveChanged", (int)self.type);
    if (self.type == PHRGroupTypeStandard) {
        Profile *profile = (Profile*)notification.object;
        [self reloadView:profile];
    }
}

- (void)handleNavBarProfileBabyActiveChanged:(NSNotification*)notification{
    DLog(@"NavBar %d ==> handleProfileActiveChanged", (int)self.type);
    if (self.type == PHRGroupTypeBaby) {
        Profile *profile = (Profile*)notification.object;
        [self reloadView:profile];
    }
}

#pragma mark - UI Actions
// UI Actions
- (IBAction)actionHome:(id)sender {
    if (self.actionEditProfile) {
        self.actionEditProfile();
    }
}

- (IBAction)actionMenu:(id)sender {
    if (self.actionSlideMenu) {
        self.actionSlideMenu();
    }
}

- (IBAction)actionFamily:(id)sender {
    if (self.actionRight) {
        self.actionRight();
    }
}

- (IBAction)actionChangeAvatar:(id)sender {
    DLog(@"Change avatar");
    // Change Avatar
    // @luonglh disable because server upload photo does not implemented yet
    if ((self.type == PHRGroupTypeStandard && !PHRAppStatus.currentStandard)
        || (self.type == PHRGroupTypeBaby && !PHRAppStatus.currentBaby)){
        return;
    }
    if (self.actionChangeAvatar) {
        self.actionChangeAvatar();
    }
}

- (IBAction)actionBack:(id)sender {
  if (self.actionBack) {
    self.actionBack();
  }
}


#pragma mark - implement KVO
-(void)observeValueForKeyPath:(NSString *)keyPath ofObject:(id)object change:(NSDictionary *)change context:(void *)context{
    UIImage *thumb = [UIImage imageNamed:@"Profile_No_Thumb"];
    if ([keyPath isEqualToString:@"avatar"]) {
        [self.imageAvatar sd_setImageWithURL:[NSURL URLWithString:change[@"new"]] placeholderImage:thumb options:SDWebImageRefreshCached];
    }
}

@end
