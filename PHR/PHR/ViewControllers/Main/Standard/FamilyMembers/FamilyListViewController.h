//
//  FamilyListViewController.h
//  PHR
//
//  Created by SonNV1368 on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRContextMenuItem.h"
#import "BaseHomeViewController.h"

@interface FamilyListViewController : BaseHomeViewController <UICollectionViewDataSource, UICollectionViewDelegate>{
    
}

@property (weak, nonatomic) IBOutlet UIImageView *imgBackground;
@property (strong, nonatomic) IBOutlet UICollectionView *collectionViewFamily;
@property (weak, nonatomic) IBOutlet UIImageView *imgHelp;
@property (nonatomic, weak, readonly) NSMutableArray *listProfile;
@property (weak, nonatomic) IBOutlet UIView *imageViewOpacity;
@property (weak, nonatomic) IBOutlet UIView *viewAddNewAccount;
@property (weak, nonatomic) IBOutlet UILabel *labelAddNewAccount;
@property (nonatomic) BOOL isShowHelpImage;
@property (weak, nonatomic) IBOutlet UILabel *labelHowTo;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;

@end
