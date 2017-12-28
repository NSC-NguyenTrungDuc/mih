//
//  ChildrenDashboardViewController.m
//  PHR
//
//  Created by Tran Hoang Ha on 8/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ChildrenDashboardViewController.h"

@interface ChildrenDashboardViewController ()<CTAssetsPickerControllerDelegate> {
    NSMutableArray *_listViewController;
}
@end

@implementation ChildrenDashboardViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self.viewOpacity setBackgroundColor:[[UIColor blackColor] colorWithAlphaComponent:0.2]];
    [self setupHomeNavigationBar:PHRGroupTypeBaby];
    // Do any additional setup after loading the view from its nib.
    _listViewController = [[NSMutableArray alloc] init];
    [self setUpViewControllers];
    [self initTabbarType];
    [self initTriangleView];
    [_carouselView setType:iCarouselTypeLinear];
    [_carouselView scrollToItemAtIndex:0 animated:NO];
    [_carouselView setPagingEnabled:YES];
  
  [self.customNavBar.btnBack addTarget:self action:@selector(backTimeline) forControlEvents:UIControlEventTouchUpInside];
}

- (void)backTimeline{
  NSLog(@"Back");
  [_carouselView scrollToItemAtIndex:0 animated:NO];
  self.customNavBar.imageAvatar.hidden = NO;
  [self.customNavBar.btnBack setImage:nil forState:UIControlStateNormal];
  self.customNavBar.labelTitle.hidden = NO;
  __weak typeof(self) weak = self;
  [self.customNavBar setActionChangeAvatar:^(){
    // Change avatar
    [NSUtils createPhotoLibrary:weak andViewController:weak];
    [weak.customNavBar reloadView];
  }];
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackgroundBaby:self.imageBackground];
}

- (void)viewDidDisappear:(BOOL)animated {
    [super viewDidDisappear:animated];

}


- (void)initTabbarType {
    NSDictionary *typeTimeline = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleTimeline) };
    NSDictionary *typeMedicines = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleMedicine)};
    NSDictionary *typeFood = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleFood)};
    NSDictionary *typeGrowth = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleGrowth)};
    NSDictionary *typeMilk = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleMilk)};
    NSDictionary *typeDiaper = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleDiaper)};
    NSDictionary *typeSleep = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kBabyTitleSleep)};
    NSArray* arr = @[typeTimeline,typeMedicines,typeFood,typeGrowth,typeMilk,typeDiaper,typeSleep];
    self.tabbarType.topMenuDelegate = self;
    self.tabbarType.backgroundColor = [UIColor colorWithRed:97./255. green:75./255. blue:91./255. alpha:1.];
    [self.tabbarType setTextFont:[FontUtils aileronSemiBoldWithSize:15.0f]];
    [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
    float triangleWidth = 12;
    float triangleHeight = 8;
    TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
    [triangle setBackgroundColor:[UIColor clearColor]];
    triangle.arrayRGB = [NSArray arrayWithObjects:@"97",@"75", @"91", nil];
    triangle.isDown = YES;
    [self.triangleView addSubview:triangle];
}

- (void)setUpViewControllers {
    
    ChildrenHomeViewController *childrenHomeVC = [[ChildrenHomeViewController alloc] initWithNibName:NSStringFromClass([ChildrenHomeViewController class]) bundle:nil];
    childrenHomeVC.delegate = self;
                                                                                                                       
    ChildrenMedicinesViewController *controllerMedicine = [[ChildrenMedicinesViewController alloc] initWithNibName:NSStringFromClass([ChildrenMedicinesViewController class]) bundle:nil];
    controllerMedicine.type = PHRGroupTypeBaby;
    controllerMedicine.delegate = self;
    
    BabyFoodDetailViewController *controllerFood = [[BabyFoodDetailViewController alloc] initWithNibName:NSStringFromClass([BabyFoodDetailViewController class]) bundle:nil];
    controllerFood.delegate = self;
    
    BabyGrowthDetailViewController *controllerGrowth = [[BabyGrowthDetailViewController alloc] initWithNibName:NSStringFromClass([BabyGrowthDetailViewController class]) bundle:nil];
    controllerGrowth.delegate = self;
    
    BabyMilkViewController *controllerMilk = [[BabyMilkViewController alloc] initWithNibName:NSStringFromClass([BabyMilkViewController class]) bundle:nil];
    controllerMilk.delegate = self;
    
    ListDiapersViewController *controllerDiaper = [[ListDiapersViewController alloc] initWithNibName:NSStringFromClass([ListDiapersViewController class]) bundle:nil];
    controllerDiaper.type = PHRGroupTypeBaby;
    controllerDiaper.delegate = self;
    
    PHRBabySleepViewController *controllerSleep = [[PHRBabySleepViewController alloc] initWithNibName:NSStringFromClass([PHRBabySleepViewController class]) bundle:nil];
    controllerSleep.delegate = self;
    
    [_listViewController addObjectsFromArray:@[childrenHomeVC,
                                               controllerMedicine,
                                               controllerFood,
                                               controllerGrowth,
                                               controllerMilk,
                                               controllerDiaper,
                                               controllerSleep]];
    _carouselView.dataSource = self;
    _carouselView.delegate = self;
    [_carouselView reloadData];
}

#pragma mark - TopMenuScrollView delegate
- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView{
    // Do nothing
}


- (void)selectTopMenu:(NSInteger)tagId {
    if (self.carouselView.currentItemIndex != tagId) {
        [self.carouselView setCurrentItemIndex:tagId];
      
      if (tagId != 0) {
        self.customNavBar.imageAvatar.hidden = YES;
        self.customNavBar.labelTitle.hidden = YES;
        [self.customNavBar.btnBack setImage:[UIImage imageNamed:@"Icon_Person"] forState:UIControlStateNormal];
        [self.customNavBar setActionChangeAvatar:nil];
      }else{
        self.customNavBar.imageAvatar.hidden = NO;
        self.customNavBar.labelTitle.hidden = NO;
        [self.customNavBar.btnBack setImage:nil forState:UIControlStateNormal];
      }
      
    }
}

#pragma mark - iCarouselDelegate
- (void)carouselCurrentItemIndexDidChange:(iCarousel *)carousel {
    [self.tabbarType setScrollPage:carousel.currentItemIndex];
    [self setIsShowDialog];
}

- (void)carouselWillBeginDragging:(iCarousel *)carousel {
    NSLog(@"Carousel will begin dragging");
}

- (void)carouselDidEndDragging:(iCarousel *)carousel willDecelerate:(BOOL)decelerate {
    NSLog(@"Carousel did end dragging and %@ decelerate", decelerate? @"will": @"won't");
}

- (void)carouselWillBeginDecelerating:(iCarousel *)carousel {
    NSLog(@"Carousel will begin decelerating");
}

- (void)carouselDidEndDecelerating:(iCarousel *)carousel {
    NSLog(@"Carousel did end decelerating");
}

- (void)carouselWillBeginScrollingAnimation:(iCarousel *)carousel {
    NSLog(@"Carousel will begin scrolling");
}

- (void)carouselDidEndScrollingAnimation:(iCarousel *)carousel {
    NSLog(@"Carousel did end scrolling");
  
  if ((long)carousel.currentItemIndex != 0) {
    self.customNavBar.imageAvatar.hidden = YES;
    [self.customNavBar.btnBack setImage:[UIImage imageNamed:@"Icon_Person"] forState:UIControlStateNormal];
    self.customNavBar.labelTitle.hidden = YES;
    [self.customNavBar setActionChangeAvatar:nil];
  }else{
    self.customNavBar.imageAvatar.hidden = NO;
    [self.customNavBar.btnBack setImage:nil forState:UIControlStateNormal];
    self.customNavBar.labelTitle.hidden = NO;
  }
  
  
}

- (CGFloat)carouselItemWidth:(iCarousel *)carousel {
    return _carouselView.frame.size.width;
}

- (void)setIsShowDialog {
    for (int i = 0;i < _listViewController.count; i++) {
        Base2ViewController *viewController = [_listViewController objectAtIndex:i];
        if (i == _carouselView.currentItemIndex) {
            [viewController setIsShowDialog:YES];
            [viewController refreshAllView];
        }  else {
            [viewController setIsShowDialog:NO];
        }
    }
}

#pragma mark - iCarouselDataSource
- (NSInteger)numberOfItemsInCarousel:(iCarousel *)carousel {
    return _listViewController.count;
}

- (UIView *)carousel:(iCarousel *)carousel viewForItemAtIndex:(NSInteger)index reusingView:(nullable UIView *)view {
    UIViewController *viewController = _listViewController[index];
    viewController.view.frame = _carouselView.frame;
    return viewController.view;
}

- (CGFloat)carousel:(iCarousel *)carousel valueForOption:(iCarouselOption)option withDefault:(CGFloat)value {
    switch (option) {
        case iCarouselOptionWrap:
            return 1;
        default:
            break;
    }
    
    return value;
}

#pragma mark - Base2ViewControllerDelegate
- (void)presentViewControllerOnDashboard:(UIViewController *)viewController {
    [self presentViewController:viewController animated:YES completion:nil];
}

- (void)openViewControllerAtIndex:(PHRBabyGroupType)type {
    switch (type) {
        case PHRBabyGroupTypeMedicine:
            [_carouselView scrollToItemAtIndex:1 animated:NO];
            break;
        case PHRBabyGroupTypeFood:
            [_carouselView scrollToItemAtIndex:2 animated:NO];
            break;
        case PHRBabyGroupTypeGrowth:
            [_carouselView scrollToItemAtIndex:3 animated:NO];
            break;
        case PHRBabyGroupTypeMilk:
            [_carouselView scrollToItemAtIndex:4 animated:NO];
            break;
        case PHRBabyGroupTypeDiaper:
            [_carouselView scrollToItemAtIndex:5 animated:NO];
            break;
        case PHRBabyGroupTypeSleep:
            [_carouselView scrollToItemAtIndex:6 animated:NO];
            break;
        default:
            break;
    }
}

- (UIImage*)takeScreenShot {
    return [UIUtils screenshot:self.view];
}

- (void)removeAllObserve {
    for (int i = 0;i < _listViewController.count; i++) {
        Base2ViewController *viewController = [_listViewController objectAtIndex:i];
        [viewController removeObserve];
    }
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
