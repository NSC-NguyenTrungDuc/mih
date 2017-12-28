//
//  BaseViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BaseViewController.h"

@interface BaseViewController () {
    
}

@end

@implementation BaseViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.ratingScreen = [RatingSleepDialog createView];
}
- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Slide menu
// ------------------------ Slide Menu ----------------------
- (void)enableSlideMenu:(BOOL)isEnable {
    if(isEnable) {
        // Enable slide menu
        [self.mm_drawerController setOpenDrawerGestureModeMask:MMOpenDrawerGestureModeBezelPanningCenterView];
        [self.mm_drawerController setCloseDrawerGestureModeMask:MMCloseDrawerGestureModeAll];
    } else {
        // Disable slide menu
        [self.mm_drawerController setOpenDrawerGestureModeMask:MMOpenDrawerGestureModeNone];
        [self.mm_drawerController setCloseDrawerGestureModeMask:MMCloseDrawerGestureModeAll];
    }
}

#pragma mark - Set STANDARD BACKGROUND

- (UIImage*)getStandardLocalImageWithIndex:(int)index{
    if (PHRAppStatus.backgroundImageList.count > 0) {
        LocalStorageImage *image = (LocalStorageImage *) [PHRAppStatus.backgroundImageList objectAtIndex:index];
        UIImage *realImage = [UIImage imageWithData:image.imageData];
        return realImage;
    } else {
        return [UIImage imageNamed:BG_Standard_Medicine];
    }
}

- (void)setImageToBackgroundStandard:(UIImageView *)imageBackground {
    PHRAppStatus.back = [[BackgroundSettingInfo objectsWhere:[NSString stringWithFormat:@"userID='%@'", PHRAppStatus.masterProfileId]] lastObject];
    if (!PHRAppStatus.back) {
        [imageBackground setImage:[UIImage imageNamed:BG_Standard_Medicine]];
    } else if (PHRAppStatus.back && PHRAppStatus.back.isStorageStandard == NO) {
        [imageBackground setImage:[UIImage imageNamed:PHRAppStatus.back.imageNameStandard]];
    } else {
        [imageBackground setImage:[self getStandardLocalImageWithIndex:PHRAppStatus.back.standardImageSelectedIndex]];
    }
}

- (void)setImageToBackgroundStandardWithBlur:(UIImageView *)imageBackground {
    if (!PHRAppStatus.back) {
        [imageBackground setImage:[[UIImage imageNamed:BG_Standard_Medicine] applyLightEffect]];
    } else if (PHRAppStatus.back && PHRAppStatus.back.isStorageStandard == NO) {
        [imageBackground setImage:[[UIImage imageNamed:PHRAppStatus.back.imageNameStandard] applyLightEffect]];
    } else {
        [imageBackground setImage:[[self getStandardLocalImageWithIndex:PHRAppStatus.back.standardImageSelectedIndex] applyLightEffect]];
    }
}

#pragma mark - Set BABY BACKGROUND
- (UIImage*)getBabyLocalImageWithIndex:(int)index{
    if (PHRAppStatus.backgroundImageList.count > 0) {
        LocalStorageImage *image = (LocalStorageImage *) [PHRAppStatus.backgroundImageList objectAtIndex:index];
        UIImage *realImage = [UIImage imageWithData:image.imageData];
        return realImage;
    } else {
        return [UIImage imageNamed:BG_Baby_Medicine];
    }
}

- (void)setImageToBackgroundBaby:(UIImageView *)imageBackground {
    if (!PHRAppStatus.back) {
        [imageBackground setImage:[UIImage imageNamed:BG_Baby_Medicine]];
    } else if (PHRAppStatus.back && PHRAppStatus.back.isStorageBaby == NO) {
        [imageBackground setImage:[UIImage imageNamed:PHRAppStatus.back.imageNameBaby]];
    } else {
        [imageBackground setImage:[self getBabyLocalImageWithIndex:PHRAppStatus.back.babyImageSelectedIndex]];
    }
}

- (void)setImageToBackgroundBabyWithBlur:(UIImageView *)imageBackground {
    if (!PHRAppStatus.back) {
        [imageBackground setImage:[[UIImage imageNamed:BG_Baby_Medicine] applyLightEffect]];
    } else if (PHRAppStatus.back && PHRAppStatus.back.isStorageBaby == NO) {
        [imageBackground setImage:[[UIImage imageNamed:PHRAppStatus.back.imageNameBaby] applyLightEffect]];
    } else {
        [imageBackground setImage:[[self getBabyLocalImageWithIndex:PHRAppStatus.back.babyImageSelectedIndex] applyLightEffect]];
    }
}

- (void)setImageToBackground:(UIImageView *)imageBackground{
    if (PHRAppStatus.type == PHRGroupTypeStandard) {
        [self setImageToBackgroundStandard:imageBackground];
    } else if (PHRAppStatus.type == PHRGroupTypeBaby){
        [self setImageToBackgroundBaby:imageBackground];
    }
}

@end
