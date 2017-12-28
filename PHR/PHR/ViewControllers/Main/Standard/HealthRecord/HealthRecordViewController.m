//
//  HealthRecordViewController.m
//  PHR
//
//  Created by BillyMobile on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HealthRecordViewController.h"
#import "DiseasesListViewController.h"
#import "ProgressCourseNoteViewController.h"


@interface HealthRecordViewController () {
  NSMutableArray *_listViewController;
}
@property (nonatomic, assign) int currentControllerIndex;
@end

@implementation HealthRecordViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  
  [self setupNavigationBarTitle:kLocalizedString(kTitleHealthRecord) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Standand_Health_Record" isDismissView:false colorLeft:[UIColor colorWithRed:34.0/255.0 green:62.0/255.0 blue:110.0/255.0 alpha:0.8] colorRight:[UIColor colorWithRed:42.0/255.0 green:90.0/255.0 blue:103.0/255.0 alpha:0.8]];
  _listViewController = [[NSMutableArray alloc] init];
  [self setUpViewControllers];
  [self initTabbarType];
  [_carouselView setType:iCarouselTypeLinear];
  [_carouselView scrollToItemAtIndex:0 animated:NO];
  [_carouselView setPagingEnabled:YES];
  [self.view setClipsToBounds:YES];
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.imageBackground];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(notifyUpdateChildView) name:kNotifyProfileStandardActiveChanged object:nil];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  NSArray *viewControllers = self.navigationController.viewControllers;
  if ([viewControllers indexOfObject:self] == NSNotFound) {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
  }
}

- (void)notifyUpdateChildView {
  [[_listViewController objectAtIndex:1] reloadTableData];
  [[_listViewController objectAtIndex:0] reloadPatientClinic];
}


- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)setUpViewControllers {
  
  ProgressCourseNoteViewController *progressCourseVC = [[ProgressCourseNoteViewController alloc]initWithNibName:NSStringFromClass([ProgressCourseNoteViewController class])  bundle:nil];
  
  
  DiseasesListViewController *diseasesVC = [[DiseasesListViewController alloc]initWithNibName:NSStringFromClass([DiseasesListViewController class]) bundle:nil];
  diseasesVC.title = kLocalizedString(kTitleDiseases);
  
  __weak __typeof__(ProgressCourseNoteViewController) *weakProgressCourseNoteVC = progressCourseVC;
  __weak __typeof__(DiseasesListViewController) *weakDiseasesListVC = diseasesVC;
  __weak __typeof__(self) weakSelf = self;
  
  [diseasesVC setOpenDiseasesViewController:^(DiseasesViewController *controller) {
    [weakSelf.navigationController pushViewController:controller animated:YES];
  }];
  
  [progressCourseVC setDidFinishGettingDiseasesList:^(NSArray *diseasesList) {
    [weakDiseasesListVC setListDiseases:diseasesList];
  }];
  [progressCourseVC setOpenShowImageViewController:^(UIImage *image) {
    [weakSelf showImage:[[UIImageView alloc] initWithImage:image]];
  }];
  [progressCourseVC setOpenWebViewController:^(UIViewController *controller) {
    [weakSelf.navigationController pushViewController:controller animated:YES];
  }];
  
  [self.navBarRightIcon setActionBack:^(){
    if (weakSelf.currentControllerIndex == 0) {
      if (weakProgressCourseNoteVC.tableViewClinic.isHidden) {
        weakProgressCourseNoteVC.tableViewClinic.hidden = NO;
      } else {
        [weakSelf.navigationController popViewControllerAnimated:YES];
      }
    } else {
      [weakSelf.navigationController popViewControllerAnimated:YES];
    }
  }];
  
  [_listViewController addObjectsFromArray:@[progressCourseVC,
                                             diseasesVC]];
  _carouselView.dataSource = self;
  _carouselView.delegate = self;
  [_carouselView reloadData];
}

- (void)initTabbarType {
  NSDictionary *typeCourse = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kTitleCourseNote) };
  NSDictionary *typeDiseases = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kTitleDiseases)};
  NSArray* arr = @[typeCourse,typeDiseases];
  self.tabbarType.topMenuDelegate = self;
  self.tabbarType.backgroundColor = [UIColor clearColor];
  [self.tabbarType setTextFont:[FontUtils aileronSemiBoldWithSize:18.0f]];
  [self.tabbarType calcurateWidth:arr];
}

#pragma mark - TopMenuScrollView delegate
- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView{
  // Do nothing
}


- (void)selectTopMenu:(NSInteger)tagId {
  if (self.carouselView.currentItemIndex != tagId) {
    [self.carouselView setCurrentItemIndex:tagId];
  }
}

#pragma mark - iCarouselDelegate
- (void)carouselCurrentItemIndexDidChange:(iCarousel *)carousel {
  [self.tabbarType setScrollPage:carousel.currentItemIndex];
  self.currentControllerIndex = (int)carousel.currentItemIndex;
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
}

- (CGFloat)carouselItemWidth:(iCarousel *)carousel {
  return _carouselView.frame.size.width;
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


@end
