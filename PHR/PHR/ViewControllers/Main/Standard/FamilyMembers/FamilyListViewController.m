//
//  FamilyListViewController.m
//  PHR
//
//  Created by SonNV1368 on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "FamilyListViewController.h"
#import "FamilyViewCell.h"
#import "PHRContextMenu.h"
#import "PHRContextMenuItem.h"
#import "ProfileViewController.h"
#import "ProfileChildrenViewController.h"
#import "LocalStorageImage.h"

#define COLOR_PROFILE_CHOOSEN RGBA(104.0,175.0,179.0, 0.5)

@interface FamilyListViewController ()<ContextMenuDelegate, UIGestureRecognizerDelegate>{
  UIImageView *imgTap;
  UIImageView *imgEdit;
  UIImageView *imgActive;
  UIImageView *imgDelete;
  UILabel* labelHoldProfile;
  UILabel* labelEdit;
  UILabel* labelActive;
  UILabel* labelDelete;
}

@end


static NSString * const kHelpImageShown = @"kHelpImageShown";

@implementation FamilyListViewController {
  PHRContextMenu *menu;
  UILongPressGestureRecognizer *longPress;
}

static NSString *const indentifier = @"FamilyViewCell";

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
  self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
  if (self) {
    // Custom initialization
  }
  return self;
}

- (void)viewDidLoad {
  [super viewDidLoad];
  //  [self setupHomeNavigationBar:self.type];
  [self setupNavigationBarTitle:kLocalizedString(kListAccount) iconLeft:nil iconRight:@"Icon_Family" iconMiddle:nil isDismissView:false colorLeft:[UIColor clearColor] colorRight:[UIColor clearColor]];
  [self setUIMenu];
  
  // Register notification
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileStandardChanged:) name:kNotifyAvatarStandardChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileBabyChanged:) name:kNotifyAvatarBabyChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileStandardChanged:) name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileBabyChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
  
  UITapGestureRecognizer *singleFingerTap =
  [[UITapGestureRecognizer alloc] initWithTarget:self
                                          action:@selector(handleTapImageHelp)];
  singleFingerTap.delegate = self;
  [self.imgHelp setUserInteractionEnabled:YES];
  [self.imgHelp addGestureRecognizer:singleFingerTap];
  
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self initializeView];
  // Load data
  [self getData];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
}

- (void)dealloc {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.viewIndicator setHidden:NO];
  } else {
    [self.viewIndicator setHidden:YES];
  }
}

#pragma mark - Set STANDARD BACKGROUND
//- (UIImage*)getStandardLocalImageWithIndex:(int)index{
//    RLMResults *imageList = [LocalStorageImage allObjects];
//    if (imageList > 0) {
//        LocalStorageImage *image = (LocalStorageImage *) [imageList objectAtIndex:index];
//        UIImage *realImage = [UIImage imageWithData:image.imageData];
//        return realImage;
//    } else {
//        return [UIImage imageNamed:BG_Standard_Medicine];
//    }
//}
//
//- (void)setImageToBackgroundStandard {
//    NSLog(@"[BackgroundSettingInfo allObjects] : %@",[BackgroundSettingInfo allObjects]);
//    back = [[BackgroundSettingInfo allObjects] lastObject];
//
//    if (!back) {
//        [self.imgBackground setImage:[UIImage imageNamed:BG_Standard_Medicine]];
//    } else if (back && back.isStorageBaby == NO) {
//        [self.imgBackground setImage:[UIImage imageNamed:back.imageNameStandard]];
//    } else {
//        [self.imgBackground setImage:[self getStandardLocalImageWithIndex:back.standardImageSelectedIndex]];
//    }
//}
//
//#pragma mark - Set BABY BACKGROUND
//- (UIImage*)getBabyLocalImageWithIndex:(int)index{
//    RLMResults *imageList = [LocalStorageImage allObjects];
//    if (imageList > 0) {
//        LocalStorageImage *image = (LocalStorageImage *) [imageList objectAtIndex:index];
//        UIImage *realImage = [UIImage imageWithData:image.imageData];
//        return realImage;
//    } else {
//        return [UIImage imageNamed:BG_Baby_Medicine];
//    }
//}
//
//- (void)setImageToBackgroundBaby {
//    NSLog(@"[BackgroundSettingInfo allObjects] : %@",[BackgroundSettingInfo allObjects]);
//    back = [[BackgroundSettingInfo allObjects] lastObject];
//
//    if (!back) {
//        [self.imgBackground setImage:[UIImage imageNamed:BG_Baby_Medicine]];
//    } else if (back && back.isStorageBaby == NO) {
//        [self.imgBackground setImage:[UIImage imageNamed:back.imageNameBaby]];
//    } else {
//        [self.imgBackground setImage:[self getBabyLocalImageWithIndex:back.babyImageSelectedIndex]];
//    }
//}

- (void)handleTapImageHelp {
  [self isHiddenNavigationBar:NO];
  self.imgHelp.hidden = YES;
  self.labelHowTo.hidden = YES;
}

#pragma mark - Get Data

- (void)getData {
  
  // Fill list family / baby
  if (self.type == PHRGroupTypeBaby) {
    [self requestGetListBabyProfile];
    //_listProfile = PHRAppStatus.arrayBabyProfile;
  } else if (self.type == PHRGroupTypeStandard) {
    [self requestGetListStandardProfile];
    //_listProfile = PHRAppStatus.arrayStandardProfile;
  }
}

- (void)requestGetListStandardProfile {
  [self showOrHideLoading:YES];
  [[PHRClient instance] requestStandardProfileListCompleted:^(id response){
    [PHRAppStatus parseStandardProfilesResponse:response];
    _listProfile = PHRAppStatus.arrayStandardProfile;
    [self.collectionViewFamily reloadData];
    if (_listProfile.count == 0){
      [self showHelpImage:YES];
    }
    [self showOrHideLoading:NO];
  } error:^(NSString *error){
    [self showOrHideLoading:NO];
  }];
}

- (void)showHelpImage:(BOOL) isShow {
  NSString *saved = [[NSUserDefaults standardUserDefaults] objectForKey:kHelpImageShown];
  if (!isShow || [saved isEqualToString:@"1"]) {
    [self isHiddenNavigationBar:NO];
    self.imgHelp.hidden = YES;
    self.labelHowTo.hidden = YES;
  } else {
    float iconSize = 30;
    float iconTapHeight = 45;
    imgTap = [[UIImageView alloc] initWithFrame:CGRectMake(SCREEN_WIDTH / 2.5, SCREEN_HEIGHT / 4 - iconTapHeight / 2, 30, iconTapHeight)];
    imgTap.image = [UIImage imageNamed:@"Icon_Tap"];
    [self.imgHelp addSubview:imgTap];
    
    //Image
    imgEdit = [[UIImageView alloc] initWithFrame:CGRectMake(SCREEN_WIDTH / 6, SCREEN_HEIGHT / 4 - iconSize / 2, iconSize, iconSize)];
    imgEdit.image = [UIImage imageNamed:@"Icon_Edit"];
    imgEdit.hidden = YES;
    [self.imgHelp addSubview:imgEdit];
    
    imgActive = [[UIImageView alloc] initWithFrame:CGRectMake(SCREEN_WIDTH / 6 , SCREEN_HEIGHT / 4 - iconSize / 2, iconSize, iconSize)];
    imgActive.image = [UIImage imageNamed:@"Icon_Flag"];
    imgActive.hidden = YES;
    [self.imgHelp addSubview:imgActive];
    
    imgDelete = [[UIImageView alloc] initWithFrame:CGRectMake(SCREEN_WIDTH / 6, SCREEN_HEIGHT / 4 - iconSize / 2,  iconSize, iconSize)];
    imgDelete.image = [UIImage imageNamed:@"Icon_Remove"];
    imgDelete.hidden = YES;
    [self.imgHelp addSubview:imgDelete];
    
    labelDelete = [self createLabel:CGRectMake(SCREEN_WIDTH / 6 + 20, SCREEN_HEIGHT / 2.3 - 15, 100, 30) text:kLocalizedString(kDelete) font:[FontUtils aileronRegularWithSize:16]];
    labelDelete.alpha = 0;
    [self.imgHelp addSubview:labelDelete];
    
    labelEdit = [self createLabel:CGRectMake(SCREEN_WIDTH / 6 + 110, SCREEN_HEIGHT / 2.3 - 95, 100, 30) text:kLocalizedString(kEdit) font:[FontUtils aileronRegularWithSize:16]];
    labelEdit.alpha = 0;
    [self.imgHelp addSubview:labelEdit];
    
    labelActive = [self createLabel:CGRectMake(SCREEN_WIDTH / 6 + 65, SCREEN_HEIGHT / 2.3 - 50, 100, 30) text:kLocalizedString(kSetActive) font:[FontUtils aileronRegularWithSize:16]];
    labelActive.alpha = 0;
    [self.imgHelp addSubview:labelActive];
    
    //Label
    labelHoldProfile = [self createLabel:CGRectMake(imgTap.frame.origin.x + 20, imgTap.frame.origin.y, 180, 30) text:kLocalizedString(kHoldProfile) font:[FontUtils aileronRegularWithSize:12]];
    [self.imgHelp addSubview:labelHoldProfile];
    [self movingHand];
    self.labelHowTo.hidden = NO;
    self.imgHelp.hidden = NO;
    [self isHiddenNavigationBar:YES];
    [[NSUserDefaults standardUserDefaults] setObject:@"1" forKey:kHelpImageShown];
  }
}

- (UILabel*)createLabel:(CGRect)rect text:(NSString*)text font:(UIFont*)font {
  UILabel *label = [[UILabel alloc] initWithFrame:rect];
  label.backgroundColor = [UIColor clearColor];
  label.textAlignment = NSTextAlignmentLeft;
  label.font = font;
  label.textColor = [UIColor whiteColor];
  label.numberOfLines = 0;
  label.text = text;
  return label;
}

- (void)movingHand{
  float iconSize = 30;
  imgTap.center = CGPointMake(SCREEN_WIDTH / 2.5, SCREEN_HEIGHT / 4);
  imgDelete.center = CGPointMake(SCREEN_WIDTH / 6, SCREEN_HEIGHT / 4 - iconSize / 2);
  imgActive.center = CGPointMake(SCREEN_WIDTH / 6 , SCREEN_HEIGHT / 4 - iconSize / 2);
  imgEdit.center = CGPointMake(SCREEN_WIDTH / 6, SCREEN_HEIGHT / 4 - iconSize / 2);
  imgDelete.hidden = YES;
  imgActive.hidden = YES;
  imgEdit.hidden = YES;
  imgTap.hidden = NO;
  labelActive.alpha = 0;
  labelEdit.alpha = 0;
  labelDelete.alpha = 0;
  labelHoldProfile.alpha = 1;
  imgTap.transform = CGAffineTransformIdentity;
  [UIView animateWithDuration:3 animations:^{
    imgTap.center = CGPointMake(SCREEN_WIDTH / 4.3, SCREEN_HEIGHT / 4);
    
  } completion:^(BOOL finished) {
    [UIView animateWithDuration:0.5 animations:^{
      imgDelete.hidden = NO;
      imgActive.hidden = NO;
      imgEdit.hidden = NO;
      imgTap.hidden = YES;
      labelActive.alpha = 1;
      labelEdit.alpha = 1;
      labelDelete.alpha = 1;
      labelHoldProfile.alpha = 0;
      imgDelete.center = CGPointMake(SCREEN_WIDTH / 6, SCREEN_HEIGHT / 2.3);
      imgActive.center = CGPointMake(SCREEN_WIDTH / 6 + 45, SCREEN_HEIGHT / 2.3 - 40);
      imgEdit.center = CGPointMake(SCREEN_WIDTH / 6 + 90, SCREEN_HEIGHT / 2.3 - 80);
    } completion:^(BOOL finished) {
      [self performSelector:@selector(movingHand) withObject:self afterDelay:2.0 ];
    }];
  }];
}

- (void)requestGetListBabyProfile {
  [self showOrHideLoading:YES];
  [[PHRClient instance] requestBabyProfileListCompleted:^(id response){
    [PHRAppStatus parseBabyProfilesResponse:response];
    _listProfile = PHRAppStatus.arrayBabyProfile;
    [self.collectionViewFamily reloadData];
    if (_listProfile.count == 0){
      [self showHelpImage:YES];
    }
    [self showOrHideLoading:NO];
  } error:^(NSString *error){
    [self showOrHideLoading:NO];
  }];
}

#pragma mark - Handle Notification Center
- (void)handleProfileStandardChanged:(NSNotification*)notification {
  // reload list profile
  if (self.type == PHRGroupTypeStandard) {
    if (self.collectionViewFamily) {
      [self.collectionViewFamily reloadData];
    }
  }
}

- (void)handleProfileBabyChanged:(NSNotification*)notification {
  // reload list profile
  if (self.type == PHRGroupTypeBaby) {
    if (self.collectionViewFamily) {
      [self.collectionViewFamily reloadData];
    }
  }
}

#pragma mark - Initialize View In First Run

- (void)initializeView {
  self.imageViewOpacity.backgroundColor = [[UIColor blackColor] colorWithAlphaComponent:0.3];
  if (self.type == PHRGroupTypeBaby) {
    [self setImageToBackgroundBabyWithBlur:self.imgBackground];
  }
  else {
    [self setImageToBackgroundStandardWithBlur:self.imgBackground];
  }
  [self showHelpImage:self.isShowHelpImage];
  // Register cell
  [self.collectionViewFamily registerNib:[UINib nibWithNibName:NSStringFromClass([FamilyViewCell class]) bundle:nil] forCellWithReuseIdentifier:NSStringFromClass([FamilyViewCell class])];
  
  self.viewAddNewAccount.backgroundColor = [[UIColor blackColor] colorWithAlphaComponent:0.3];
  self.viewAddNewAccount.layer.borderWidth = 1;
  self.viewAddNewAccount.layer.borderColor = [UIColor whiteColor].CGColor;
  self.viewAddNewAccount.layer.cornerRadius = 15;
  self.viewAddNewAccount.layer.masksToBounds = YES;
  self.labelAddNewAccount.text = kLocalizedString(kAddNewAccount);
  
  UITapGestureRecognizer *gestureRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(addNewAccount)];
  [self.viewAddNewAccount addGestureRecognizer:gestureRecognizer];
  
  
}

- (void)setUIMenu {
  //Create the items
  PHRContextMenuItem *editItem = [[PHRContextMenuItem alloc] initWithUnselectedIcon:[UIImage imageNamed:@"Icon_Edit"] selectedIcon:[UIImage imageNamed:@"Icon_Edit"]];
  PHRContextMenuItem *flagItem = [[PHRContextMenuItem alloc] initWithUnselectedIcon:[UIImage imageNamed:@"Icon_Flag"] selectedIcon:[UIImage imageNamed:@"Icon_Flag"]];
  PHRContextMenuItem *deleteIcon = [[PHRContextMenuItem alloc] initWithUnselectedIcon:[UIImage imageNamed:@"Icon_Remove"] selectedIcon:[UIImage imageNamed:@"Icon_Remove"]];
  //Create the menu
  menu = [[PHRContextMenu alloc] initWithMenuItems:@[editItem, flagItem, deleteIcon]];
  menu.delegate = self;
  self.labelHowTo.text = kLocalizedString(kHowToUpdate);
  
  //Create the gesture recognizer
  longPress = [[UILongPressGestureRecognizer alloc] initWithTarget:menu action:@selector(showMenuUponActivationOfGetsure:)];
  [self.collectionViewFamily addGestureRecognizer:longPress];
}

#pragma mark - Collectionview delegate

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
  return self.listProfile.count;
}

- (UICollectionViewCell*)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
  /* Uncomment this block to use subclass-based cells */
  FamilyViewCell *cell = (FamilyViewCell *)[collectionView dequeueReusableCellWithReuseIdentifier:indentifier forIndexPath:indexPath];
  if (self.type == PHRGroupTypeStandard) {
    //        if (indexPath.row == self.listProfile.count) {
    //            cell.avatarFamilyMember.image = [UIImage imageNamed:@"Profile_Add"];
    //            cell.imageFlag.image = nil;
    //            cell.imageSync.image = nil;
    //            cell.nameFamilyMember.text = @"";
    //            cell.titleFamilyMember.text = @"";
    //        }
    //        else {
    ProfileStandard *member = (ProfileStandard *)self.listProfile[indexPath.row];
    cell.nameFamilyMember.text = member.name;
    cell.titleFamilyMember.text = member.isMainProfile ? kLocalizedString(kMaster) : @"";
    cell.imageFlag.image = [member checkActive] ? [UIImage imageNamed:@"Icon_Flag"] : nil;
    if ([PHRAppStatus.currentStandard.profileId isEqualToString:member.profileId]) {
      cell.viewChoosen.backgroundColor = [UIColor colorWithRed:104./255. green:175./255. blue:179./255. alpha:0.7];
      cell.imageViewTick.hidden = NO;
    } else {
      cell.viewChoosen.backgroundColor = [UIColor clearColor];
      cell.imageViewTick.hidden = YES;
    }
    if ([member.avatar isEmpty]) {
      cell.avatarFamilyMember.layer.borderColor = [UIColor clearColor].CGColor;
      
    }
    else {
      cell.avatarFamilyMember.layer.borderColor = [UIColor whiteColor].CGColor;
      cell.avatarFamilyMember.layer.borderWidth = 2;
    }
    [cell.avatarFamilyMember setImageWithURL:[NSURL URLWithString:member.avatar] placeholderImage:[UIImage imageNamed:@"Profile_No_Thumb"]];
    // }
  }
  else if (self.type == PHRGroupTypeBaby) {
    //        if (indexPath.row == self.listProfile.count) {
    //            cell.avatarFamilyMember.image = [UIImage imageNamed:@"Profile_Add"];
    //            cell.imageFlag.image = nil;
    //            cell.imageSync.image = nil;
    //            cell.nameFamilyMember.text = @"";
    //            cell.titleFamilyMember.text = @"";
    //        }
    //        else {
    ProfileBaby *child = (ProfileBaby *)self.listProfile[indexPath.row];
    cell.nameFamilyMember.text = child.name;
    cell.titleFamilyMember.text = @"";
    cell.imageFlag.image = [child checkActive] ?[UIImage imageNamed:@"Icon_Flag"] : nil;
    
    if ([PHRAppStatus.currentBaby.profileId isEqualToString:child.profileId]) {
      cell.viewChoosen.backgroundColor = [UIColor colorWithRed:226./255. green:173./255. blue:228./255. alpha:0.7];
      cell.imageViewTick.hidden = NO;
    } else {
      cell.viewChoosen.backgroundColor = [UIColor clearColor];
      cell.imageViewTick.hidden = YES;
    }
    if ([child.avatar isEmpty]) {
      cell.avatarFamilyMember.layer.borderColor = [UIColor clearColor].CGColor;
    }
    else {
      cell.avatarFamilyMember.layer.borderColor = [UIColor whiteColor].CGColor;
      cell.avatarFamilyMember.layer.borderWidth = 2;
    }
    [cell.avatarFamilyMember setImageWithURL:[NSURL URLWithString:child.avatar] placeholderImage:[UIImage imageNamed:@"Profile_No_Thumb"]];
  }
  
  return cell;
}

- (CGSize)collectionView:(UICollectionView *)collectionView
                  layout:(UICollectionViewLayout*)collectionViewLayout
  sizeForItemAtIndexPath:(NSIndexPath *)indexPath {
  return CGSizeMake((SCREEN_WIDTH - 70)/3, 140);
}

- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath {
  if (self.type == PHRGroupTypeStandard) {
    
    // Choose profile to view data
    PHRAppStatus.currentStandard = self.listProfile[indexPath.row];
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileStandardActiveChanged object:PHRAppStatus.currentStandard userInfo:nil];
    [self.navigationController popViewControllerAnimated:YES];
    
    
  }
  else if (self.type == PHRGroupTypeBaby) {
    
    PHRAppStatus.currentBaby = self.listProfile[indexPath.row];
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileBabyActiveChanged object:PHRAppStatus.currentBaby userInfo:nil];
    [self.navigationController popViewControllerAnimated:YES];
    
  }
}

#pragma mark - Context menu

- (BOOL)shouldShowContextMenu:(PHRContextMenu *)contextMenu atPoint:(CGPoint)point {
  //If there is a cell, then the menu should activate.
  
  return YES;
}

- (void)contextMenu:(PHRContextMenu *)contextMenu atPoint:(CGPoint)point didSelectItemAtIndex:(NSInteger)index {
  NSIndexPath* indexPath = [self.collectionViewFamily indexPathForItemAtPoint:point];
  if (indexPath) {
    __weak Profile *profile = self.listProfile[indexPath.row];
    if (index == 0) {
      // Edit
      if (self.type == PHRGroupTypeStandard) {
        ProfileViewController *controller = [[ProfileViewController alloc] initWithNibName:NSStringFromClass([ProfileViewController class]) bundle:nil];
        [controller setProfile:(ProfileStandard*)profile];
        [self.navigationController pushViewController:controller animated:YES];
      }
      else if (self.type == PHRGroupTypeBaby) {
        ProfileChildrenViewController *controller = [[ProfileChildrenViewController alloc] initWithNibName:NSStringFromClass([ProfileChildrenViewController class]) bundle:nil];
        [controller setProfileBaby:(ProfileBaby*)profile];
        [self.navigationController pushViewController:controller animated:YES];
      }
    } else if (index == 1) {
      if (![profile checkActive]) {
        Profile *profile = self.listProfile[indexPath.row];
        if (profile) {
          [PHRAppDelegate showLoading];
          [[PHRClient instance] requestSetActiveStandard:(self.type == PHRGroupTypeStandard) newId:profile.profileId completed:^(id response){
            [PHRAppDelegate hideLoading];
            if (self.type == PHRGroupTypeStandard) {
              [PHRAppStatus setActiveStandardProfileId:profile.profileId];
            }
            else if (self.type == PHRGroupTypeBaby) {
              [PHRAppStatus setActiveBabyProfileId:profile.profileId];
            }
            [self.collectionViewFamily reloadData];
          } error:^(NSString *error){
            [PHRAppDelegate hideLoading];
          }];
        }
      }
      
    } else if (index == 2){
      if (profile.isActive && self.type == PHRGroupTypeStandard && !((ProfileStandard*)profile).isMainProfile) {
        // Dont accept delete
        [NSUtils showMessage:kLocalizedString(@"standard.delete.active_profile") withTitle:APP_NAME];
      } else if ([profile isMemberOfClass:[ProfileStandard class]] && ((ProfileStandard*)profile).isMainProfile) {
        // Dont accept delete
        [NSUtils showMessage:kLocalizedString(@"standard.delete.personal_profile") withTitle:APP_NAME];
      }
      else{
        // Remove
        if (self.type == PHRGroupTypeStandard) {
          [PHRAppDelegate showLoading];
          [[PHRClient instance] requestDeleteStandardProfileId:profile.profileId completed:^(id response){
            [PHRAppDelegate hideLoading];
            [PHRAppStatus removeStandardProfile:profile.profileId];
            [self.collectionViewFamily reloadData];
            [NSUtils showMessage:kLocalizedString(kDeleteProfileSuccessfully) withTitle:APP_NAME];
            if(profile.profileId == PHRAppStatus.currentStandard.profileId) {
              PHRAppStatus.currentStandard = nil;
              [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileStandardActiveChanged object:PHRAppStatus.currentStandard userInfo:nil];
            }
          } error:^(NSString* error){
            [PHRAppDelegate hideLoading];
            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
          }];
        }
        else if (self.type == PHRGroupTypeBaby) {
          [PHRAppDelegate showLoading];
          
          [[PHRClient instance] requestDeleteBabyProfileId:profile.profileId completed:^(id response){
            [PHRAppDelegate hideLoading];
            [PHRAppStatus removeBabyProfile:profile.profileId];
            [self.collectionViewFamily reloadData];
            [NSUtils showMessage:kLocalizedString(kDeleteProfileSuccessfully) withTitle:APP_NAME];
            if (profile.profileId == PHRAppStatus.currentBaby.profileId) {
              PHRAppStatus.currentBaby = nil;
              [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileBabyActiveChanged object:PHRAppStatus.currentBaby userInfo:nil];
            }
            
          } error:^(NSString *error){
            [PHRAppDelegate hideLoading];
            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
          }];
        }
      }
    }
  }
  
}

- (void)addNewAccount {
  // Add new standard profile
  if (self.type == PHRGroupTypeStandard) {
    ProfileViewController *controller = [[ProfileViewController alloc] initWithNibName:NSStringFromClass([ProfileViewController class]) bundle:nil];
    [self.navigationController pushViewController:controller animated:YES];
  }
  else {
    ProfileChildrenViewController *controller = [[ProfileChildrenViewController alloc] initWithNibName:NSStringFromClass([ProfileChildrenViewController class]) bundle:nil];
    [self.navigationController pushViewController:controller animated:YES];
  }
  
}

@end
