//
//  DisplaySettingViewController.h
//  PHR
//
//  Created by SonNV1368 on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "AccordionView.h"
#import <CTAssetsPickerController/CTAssetsPickerController.h>
#import "PHImageManager+Extension.h"

@interface DisplaySettingViewController : Base2ViewController<AccordionViewDelegate, UICollectionViewDataSource, UICollectionViewDelegate,CTAssetsPickerControllerDelegate,UIActionSheetDelegate>

@property (strong, nonatomic) IBOutlet UIView *viewContent;
@property (weak, nonatomic) IBOutlet UIImageView *BG_MainDisplay;

@property (strong, nonatomic) AccordionView *viewAccordion;
@property (strong, nonatomic) IBOutlet UIView *viewChooseBackground;
@property (strong, nonatomic) IBOutlet UIView *viewAddYourBackground;

@property (strong, nonatomic) IBOutlet UIView *viewHeaderAddYourBackground;
@property (strong, nonatomic) IBOutlet UIView *viewHeaderChooseBackground;
@property (strong, nonatomic) IBOutlet UICollectionView *collectChooseBackground;
@property (strong, nonatomic) IBOutlet UICollectionView *collectAddYourBackground;

- (IBAction)touchButtonChooseBackground:(id)sender;
- (IBAction)touchButtonAddYourBackground:(id)sender;

@end
