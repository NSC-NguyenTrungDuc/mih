//
//  BaseHomeViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "BaseViewController.h"
#import "CustomNavigationBar.h"
#import <CTAssetsPickerController/CTAssetsPickerController.h>
#import "PHImageManager+Extension.h"


@interface BaseHomeViewController : BaseViewController{
    
}

@property (strong, nonatomic) CustomNavigationBar *customNavBar;

- (void)setupHomeNavigationBar:(PHRGroupType)type;
- (void)reloadActivePerson;
- (void)setupNavigationBarTitle:(NSString *)title iconLeft:(NSString *)iconLeft iconRight:(NSString *)iconRight iconMiddle:(NSString*)iconMiddle isDismissView:(bool) isDismiss colorLeft:(UIColor*)leftColor colorRight:(UIColor*)rightColor;
- (void)isHiddenNavigationBar:(BOOL)isHidden;

@end
