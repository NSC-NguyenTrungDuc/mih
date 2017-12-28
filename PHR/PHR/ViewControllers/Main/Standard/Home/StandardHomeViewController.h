//
//  StandardHomeViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BaseHomeViewController.h"
#import "HYActivityView.h"

@interface StandardHomeViewController : BaseHomeViewController <UICollectionViewDelegate, UICollectionViewDataSource>

@property (weak, nonatomic) IBOutlet UICollectionView *collectionViewStandard;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UIButton *btnShowPropertys;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundStandard;
@property (weak, nonatomic) IBOutlet UIView *viewLoading;
@property (weak, nonatomic) IBOutlet UIButton *btnBabyMode;

@property (nonatomic, strong) NSArray *arrayItems;
@property (nonatomic, strong) NSMutableArray *arrayItemsDisplay;


- (IBAction)actionChangeToBabyMode:(id)sender;

@end
