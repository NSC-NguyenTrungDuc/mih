//
//  ChildrenDashboardViewController.h
//  PHR
//
//  Created by Tran Hoang Ha on 8/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "iCarousel.h"
#import "ChildrenMedicinesViewController.h"
#import "BabyFoodDetailViewController.h"
#import "BabyGrowthDetailViewController.h"
#import "BabyMilkViewController.h"
#import "ListDiapersViewController.h"
#import "PHRBabySleepViewController.h"
#import "ChildrenHomeViewController.h"
#import "Base2ViewController.h"
#import "BaseViewController.h"
#import "TriangleView.h"

@interface ChildrenDashboardViewController : BaseHomeViewController <iCarouselDelegate, iCarouselDataSource, TopMenuDelegate, Base2ViewControllerDelegate>
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet TopMenuScrollView *tabbarType;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (nonatomic, weak) IBOutlet iCarousel *carouselView;
@property (weak, nonatomic) IBOutlet UIView *triangleView;
- (void)removeAllObserve;
@end
