//
//  BaseHomeViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "BaseHomeViewController.h"
#import "StandardHomeViewController.h"
#import "ChildrenHomeViewController.h"
#import "FamilyListViewController.h"
#import "ProfileViewController.h"
#import "ProfileChildrenViewController.h"
#import "StandardFoodDetailViewController.h"
#import "StandardFitnessDetailViewController.h"
#import "StandardVitalsDetailViewController.h"
#import "BabyFoodDetailViewController.h"
#import "BabyGrowthDetailViewController.h"
#import "ChildrenMedicinesViewController.h"
#import "ListDiapersViewController.h"
#import "BabyMilkViewController.h"
#import <PureLayout/PureLayout.h>

@interface BaseHomeViewController () <CTAssetsPickerControllerDelegate>{
    
}
//@property (strong, nonatomic) CustomNavigationBar *customNavBar;

@end

@implementation BaseHomeViewController

- (void)viewDidLoad {
    [super viewDidLoad];
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
//    [self reloadActivePerson];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillDisappear:(BOOL)animated {
    for (CALayer* layer in [self.view.layer sublayers]) {
        [layer removeAllAnimations];
    }
}

/*
 #pragma mark - Navigation
 
 // In a storyboard-based application, you will often want to do a little preparation before navigation
 - (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
 // Get the new view controller using [segue destinationViewController].
 // Pass the selected object to the new view controller.
 }
 */

/*
 Setup navigation bar for home screen (standard and baby)
 */

- (void)setupHomeNavigationBar:(PHRGroupType)type {
    self.type = type;
    
    // Custom navigation bar
    self.customNavBar = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([CustomNavigationBar class]) owner:self options:nil] objectAtIndex:0];
    self.customNavBar.type = type;
    [self.view addSubview:self.customNavBar];
    
    [self.customNavBar autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.customNavBar autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.customNavBar autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.customNavBar autoSetDimension:ALDimensionHeight toSize:60];
    
    // Action
    __block typeof(self) safeBlock = self;
    [self.customNavBar setActionSlideMenu:^(){
        [safeBlock.mm_drawerController toggleDrawerSide:MMDrawerSideLeft animated:YES completion:^(BOOL finished) {}];
        [safeBlock enableSlideMenu:YES];
    }];
    
    __weak typeof(self) weak = self;
    [self.customNavBar setActionEditProfile:^(){
        //// Standard/Baby also pop to root
        //[safeBlock.navigationController popToRootViewControllerAnimated:YES];
        
        // Change logic
        if (type == PHRGroupTypeStandard) {
            ProfileViewController *controller = [[ProfileViewController alloc] initWithNibName:NSStringFromClass([ProfileViewController class]) bundle:nil];
            [controller setProfile:PHRAppStatus.currentStandard];
            
            [weak.navigationController pushViewController:controller animated:YES];
        }
        else if (type == PHRGroupTypeBaby) {
            ProfileChildrenViewController *controller = [[ProfileChildrenViewController alloc] initWithNibName:NSStringFromClass([ProfileChildrenViewController class]) bundle:nil];
            [controller setProfileBaby:PHRAppStatus.currentBaby];
            [weak.navigationController pushViewController:controller animated:YES];
        }
    }];
    
    [self.customNavBar setActionRight:^(){
        if ([safeBlock isMemberOfClass:[FamilyListViewController class]]) {
            return;
        }
        FamilyListViewController *family = [[FamilyListViewController alloc] initWithNibName:NSStringFromClass([FamilyListViewController class]) bundle:nil];
            family.type = type;
        [safeBlock.navigationController pushViewController:family animated:YES];
    }];
    
    [self.customNavBar setActionChangeAvatar:^(){
        // Change avatar
        [weak changeAvatar];
    }];
}

- (void)setupNavigationBarTitle:(NSString *)title iconLeft:(NSString *)iconLeft iconRight:(NSString *)iconRight iconMiddle:(NSString*)iconMiddle isDismissView:(bool) isDismiss colorLeft:(UIColor*)leftColor colorRight:(UIColor*)rightColor {
    __weak __typeof__(self) weakSelf = self;
    
    // Custom navigation bar
    self.navBarRightIcon = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([Base2NavigationBarRightIcon class]) owner:self options:nil] objectAtIndex:0];
    [self.navBarRightIcon setupWithTitle:title iconLeft:iconLeft iconRight:iconRight iconMiddle:iconMiddle colorLeft:leftColor colorRight:rightColor];
    
    [self.view addSubview:self.navBarRightIcon];
    
    [self.navBarRightIcon autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.navBarRightIcon autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.navBarRightIcon autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.navBarRightIcon autoSetDimension:ALDimensionHeight toSize:60];
    
    // back
    [self.navBarRightIcon setActionBack:^(){
        if (isDismiss) {
            [weakSelf dismissViewControllerAnimated:YES completion:nil];
        } else {
            [weakSelf.navigationController popViewControllerAnimated:YES];
        }
    }];
    __block typeof(self) safeBlock = self;
    // right action
    [self.navBarRightIcon setActionRight:^(){
        
        if ([safeBlock isMemberOfClass:[FamilyListViewController class]]) {
            return;
        }
        FamilyListViewController *family = [[FamilyListViewController alloc] initWithNibName:NSStringFromClass([FamilyListViewController class]) bundle:nil];
        if ([safeBlock isMemberOfClass:[StandardHomeViewController class]] ||
            [safeBlock isMemberOfClass:[StandardFitnessDetailViewController class]] ||
            [safeBlock isMemberOfClass:[StandardFoodDetailViewController class]] ||
            [safeBlock isMemberOfClass:[StandardVitalsDetailViewController class]]) {
            family.type = PHRGroupTypeStandard;
        }
        else if ([safeBlock isMemberOfClass:[ChildrenHomeViewController class]]
                 || [safeBlock isMemberOfClass:[BabyMilkViewController class]]
                 || [safeBlock isMemberOfClass:[BabyFoodDetailViewController class]]
                 || [safeBlock isMemberOfClass:[BabyGrowthDetailViewController class]]
                 || [safeBlock isMemberOfClass:[ChildrenMedicinesViewController class]]
                 || [safeBlock isMemberOfClass:[ListDiapersViewController class]]) {
            family.type = PHRGroupTypeBaby;
        }
        [safeBlock.navigationController pushViewController:family animated:YES];
        //[weakSelf actionNavigationBarItemRight];
    }];
}

- (void)isHiddenNavigationBar:(BOOL)isHidden {
    self.navBarRightIcon.hidden = isHidden;
}

- (void)reloadActivePerson {
    [self.customNavBar reloadView];
}

- (void)changeAvatar {
  [NSUtils createPhotoLibrary:self andViewController:self];
    
}

#pragma mark - UzysAssetsPickerControllerDelegate Methods

- (void)assetsPickerController:(CTAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets
{
    PHImageRequestOptions *requestOptions = [[PHImageRequestOptions alloc] init];
    requestOptions.resizeMode   = PHImageRequestOptionsResizeModeExact;
    requestOptions.deliveryMode = PHImageRequestOptionsDeliveryModeHighQualityFormat;
    
    [assets enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
        PHImageManager *manager = [PHImageManager defaultManager];
        CGFloat scale = UIScreen.mainScreen.scale;
        CGSize targetSize = CGSizeMake(200 * scale, 200 * scale);
        
        [manager ctassetsPickerRequestImageForAsset:assets[0]
                                         targetSize:targetSize
                                        contentMode:PHImageContentModeAspectFill
                                            options:requestOptions
                                      resultHandler:^(UIImage *image, NSDictionary *info){
                                          [self uploadImage:image];
                                      }];
    }];
    [picker dismissViewControllerAnimated:YES completion:nil];
    
}

- (BOOL)assetsPickerController:(CTAssetsPickerController *)picker shouldSelectAsset:(PHAsset *)asset
{
    NSInteger max = 1;
    
    // show alert gracefully
    if (picker.selectedAssets.count >= max)
    {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
    }
    
    // limit selection to max
    return (picker.selectedAssets.count < max);
}

//- (void)uzysAssetsPickerController:(UzysAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets {
//    if([[assets[0] valueForProperty:@"ALAssetPropertyType"] isEqualToString:@"ALAssetTypePhoto"])
//    {
//        [assets enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
//            ALAsset *representation = obj;
//            UIImage *img = [UIImage imageWithCGImage:representation.defaultRepresentation.fullResolutionImage
//                                               scale:representation.defaultRepresentation.scale
//                                         orientation:(UIImageOrientation)representation.defaultRepresentation.orientation];
//            if (img) {
//                [self uploadImage:img];
//            }
//            *stop = YES;
//        }];
//    }
//}
//
//- (void)uzysAssetsPickerControllerDidExceedMaximumNumberOfSelection:(UzysAssetsPickerController *)picker {
//    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
//}

- (void)uploadImage:(UIImage*)img{
    [[PHRClient instance] uploadProfileImageToServer:img andCompletion:^(id responseObject) {
        if (responseObject == nil) {
            dispatch_async(dispatch_get_main_queue(), ^{
                [PHRAppDelegate hideLoading];
                [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
            });
        }
        else {
            NSString *avatar = [Validator getSafeString:responseObject[@"content"]];
            if (self.type == PHRGroupTypeStandard) {
                PHRAppStatus.currentStandard.avatar = avatar;
                [[PHRClient instance] requestEditStandardProfile:PHRAppStatus.currentStandard completed:nil error:nil];
            }
            else if (self.type == PHRGroupTypeBaby) {
                PHRAppStatus.currentBaby.avatar = avatar;
                // Send request update avatar
                [[PHRClient instance] requestEditBabyProfile:PHRAppStatus.currentBaby completed:nil error:nil];
            }
        }
    }];
}


@end
