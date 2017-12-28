//
//  FamilyViewCell.h
//  PHR
//
//  Created by SonNV1368 on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface FamilyViewCell : UICollectionViewCell
@property (strong, nonatomic) IBOutlet UILabel *nameFamilyMember;
@property (strong, nonatomic) IBOutlet UILabel *titleFamilyMember;
@property (strong, nonatomic) IBOutlet UIImageView *avatarFamilyMember;
@property (strong, nonatomic) IBOutlet UIImageView *imageFlag;
@property (weak, nonatomic) IBOutlet UIView *viewChoosen;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewTick;

@end
