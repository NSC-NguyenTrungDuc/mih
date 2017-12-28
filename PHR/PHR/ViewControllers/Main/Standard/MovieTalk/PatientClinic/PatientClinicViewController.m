//
//  PatientClinicViewController.m
//  PHR
//
//  Created by Tran Hoang Ha on 10/6/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PatientClinicViewController.h"
#import "BaseNetworking.h"
#import "PatientClinicTableViewCell.h"
#import "PHRBookingListViewController.h"
#import "PatientClinicViewModel.h"
#import "PatientClinicDataSource.h"
#import "PatientClinicDelegate.h"

@interface PatientClinicViewController () <UITableViewDelegate, UITableViewDataSource>
@property (nonatomic, weak) IBOutlet UITableView *tableView;
@property (nonatomic, weak) IBOutlet UILabel *labelHeader;
@property (nonatomic, weak) IBOutlet UIImageView *imageBackground;
@property (nonatomic, weak) IBOutlet UIView *titleView;
@property (nonatomic, strong) NSMutableArray *listViewModel;
@property (nonatomic, strong) PatientClinicDelegate *patientClinicDelegate;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;
@property (weak, nonatomic) IBOutlet UIView *viewEmpty;
@property (nonatomic, strong) PatientClinicDataSource *patientClinicDataSource;
@end

@implementation PatientClinicViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  
  _viewEmpty.hidden = YES;
  
  [self setUpView];
  [self requestPatientClinicWithProfileID:PHRAppStatus.currentStandard.profileId];
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileStandardActiveChanged object:nil];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  NSArray *viewControllers = self.navigationController.viewControllers;
  if ([viewControllers indexOfObject:self] == NSNotFound) {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
  }
}

- (void)handleProfileActiveChanged:(NSNotification*)notification {
  if (self.listViewModel.count > 0) {
    [self.listViewModel removeAllObjects];
    [self.tableView reloadData];
  }
  [self requestPatientClinicWithProfileID:PHRAppStatus.currentStandard.profileId];
}

- (void)setUpView {
  [self setImageToBackgroundStandard:self.imageBackground];
  [self setupNavigationBarTitle:kLocalizedString(kMyOnlineBooking)
                       iconLeft:@"Icon_Person"
                      iconRight:@"Icon_Family"
                     iconMiddle:@"icon_movie_talk_mybooking"
                  isDismissView:false
                      colorLeft:PHR_COLOR_MOVIE_TALK_NAV_LEFT
                     colorRight:PHR_COLOR_MOVIE_TALK_NAV_RIGHT];
  [UIUtils setGradientColorWithLeft:PHR_COLOR_MOVIE_TALK_HEADER_LEFT
                           andRight:PHR_COLOR_MOVIE_TALK_HEADER_RIGHT
                            forView:_titleView];
  _labelHeader.text = kLocalizedString(kPatientClinicHeaderTitle);
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.viewIndicator setHidden:NO];
  } else {
    [self.viewIndicator setHidden:YES];
  }
}

- (void)requestPatientClinicWithProfileID:(NSString *)profileID {
  [self showOrHideLoading:YES];
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Clinic"]];
  NSString *URL = [NSString stringWithFormat:API_PHR03, profileID, PHRAppStatus.token];
  [[[BaseNetworking sharedInstance] fetchRequest:URL params:nil] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    if (t.cancelled) {
      DLog(@"Cancelled");
    } else if (t.faulted) {
      DLog(@"Error: %@", t.error)
    } else {
      DLog(@"______%@", t.result);
      [self handleResponseWithTask:t];
    }
    return nil;
  }];
}

- (void)handleResponseWithTask:(BFTask *)t {
  NSDictionary *dictResponse = (NSDictionary *)t.result;
  NSDictionary *dictContent = [dictResponse objectForKey:KEY_Content];
  
  if ([dictContent objectForKey:kPHR03ListAccountClinic] &&
      [dictContent objectForKey:kPHR03ListAccountClinic] != [NSNull null]) {
    NSArray *accountClinic = [dictContent objectForKey:kPHR03ListAccountClinic];
    for (id dictAccountClinic in accountClinic) {
      if (![dictAccountClinic isKindOfClass:[NSDictionary class]]) {
        break;
      }
      PatientClinicViewModel *viewModel = [[PatientClinicViewModel alloc] initWithModel:[[PatientClinic alloc] initWithDictionary:dictAccountClinic]];
      if (!_listViewModel) {
        _listViewModel = [[NSMutableArray alloc] init];
      }
      [_listViewModel addObject:viewModel];
    }
    
    if (_listViewModel.count == 0) {
      _viewEmpty.hidden = NO;
    }else{
      _viewEmpty.hidden = YES;
      [self initDataSourceAndDelegateForTable];
      [self reloadTableView];
    }
  }
  [self showOrHideLoading:NO];
}

- (void)initDataSourceAndDelegateForTable {
  _patientClinicDataSource = [[PatientClinicDataSource alloc] initWithTableView:_tableView
                                                               andListViewModel:_listViewModel];
  _patientClinicDelegate = [[PatientClinicDelegate alloc] initWithViewController:self andTableView:_tableView andListViewModel:_listViewModel];
}

- (void)reloadTableView {
  [_tableView reloadData];
}

#pragma mark - UITableViewDataSource
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  return [_patientClinicDataSource numberOfItemInSections:section];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  return [_patientClinicDataSource cellForItemAtIndexPath:indexPath];
}

#pragma mark - UITableViewDelegate
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return [_patientClinicDelegate heightForItem];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  [_patientClinicDelegate didSelectItemAtIndexPath:indexPath];
}
@end

