//
//  ProfileViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "ProfileViewController.h"
#import "ProfileStandard.h"
#import "IQActionSheetPickerView.h"
#import "LinkedAcccountTableViewCell.h"
#import "SearchHospitalViewController.h"

static NSString *LinkedAccCellIdentifier    = @"LinkedAccCellIdentifier";
static float const ClinicCellHeightExpanding = 200;
static float const ClinicCellHeightCollapsed = 60;

@interface ProfileViewController () <UITableViewDataSource, UITableViewDelegate, IQActionSheetPickerViewDelegate> {
    UITableView *tableClinicAccount;
    UIButton *btnAddAccLinked;
    NSMutableDictionary *_dictExpanding;
    
    ClinicHospital *_selectedHospital;
    NSString *_selectedClinicId;
    BOOL _needToClearFirstCell;
}

@property (strong, nonatomic, readonly) ProfileStandard *standardProfile;
@property (nonatomic, assign) BOOL isEditMode;
@property (nonatomic, assign) BOOL isChangedAvatar;

@end

@implementation ProfileViewController {
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
    _dictExpanding = [[NSMutableDictionary alloc] init];
    // Init
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(setTitleToLinkedAcc:) name:ChangeTitleAccLinked object:nil];
    arrayTextProfileInfo = [[NSMutableArray alloc] init];
    // UI
    [self initializeProfileView];
    // Navigation bar
    [self setupNavigationBarTitle:kLocalizedString(kProfile) titleIcon:@"Profile" rightItem:kLocalizedString(kSave)];
    
    // Load data
    if (self.standardProfile && self.standardProfile.profileId) {
        [self loadData];
    }
    else{
        _standardProfile = [[ProfileStandard alloc] init];
       
    }
    if(self.standardProfile && self.standardProfile.profileId && self.standardProfile.isMainProfile) {
        self.txtOccupation.placeholder = kLocalizedString(kOccupation);
    } else {
         self.txtOccupation.placeholder = kLocalizedString(kRelationship);
    }
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.imageBackground];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)setProfile:(ProfileStandard*)profile {
    _standardProfile = profile;
    if (profile) {
        self.isEditMode = YES;
    }
    else{
        _standardProfile = [[ProfileStandard alloc] init];
    }
}

- (void)showOrHideLoading:(BOOL)isShowed{
//    if (isShowed) {
//        [PHRAppDelegate showLoadingInView:viewLinkedClinicAcc];
//    } else {
//        [PHRAppDelegate hideLoadingInView:viewLinkedClinicAcc];
//    }
}

#pragma mark - Load data
- (void)loadData {
    //[PHRAppDelegate showLoading];
    [self showOrHideLoading:YES];
    [[PHRClient instance] requestGetDetailStandardProfileId:self.standardProfile.profileId completed:^(id response){
        if (response && response[KEY_Content] != [NSNull null]) {
            _standardProfile = [[ProfileStandard alloc] initWithDictionary:response[KEY_Content]];
        }
        // Fill data
        [self fillStandardProfile];
        [self showOrHideLoading:NO];
    } error:^(NSString *error){
        [self showOrHideLoading:NO];
        //[PHRAppDelegate hideLoading];
    }];
}

#pragma mark - Fill Data If Have

- (void)fillStandardProfile {
    if (_standardProfile) {
        self.txtName.text = self.standardProfile.name;
//        self.txtNickname.text = self.standardProfile.nickName;
        [self.comboboxGender setText:self.standardProfile.gender];
        self.txtNameKana.text = self.standardProfile.nameKana;
        self.txtZipCode.text = self.standardProfile.zipCode;
        self.txtPrefecture.text = self.standardProfile.prefecture;
        self.txtCity.text = self.standardProfile.city;
        self.txtAddress.text = self.standardProfile.address;
        if (self.standardProfile && self.standardProfile.profileId && self.standardProfile.isMainProfile) {
            self.txtOccupation.text = self.standardProfile.occupation;
        } else {
             self.txtOccupation.text = self.standardProfile.relationship;
        }
        // Birthday
        self.txtBirthday.text = [self updateTime:self.standardProfile.birthday];
        // Avatar
        [self.imgAvatar sd_setImageWithURL:[NSURL URLWithString:self.standardProfile.avatar] placeholderImage:[UIImage imageNamed:@"IconCamera"] options:SDWebImageRefreshCached];
        
        // reload table clinic account
        [tableClinicAccount reloadData];
        [self reloadTableClinicFrame];
    }
    [PHRAppDelegate hideLoading];
}

- (void)reloadTableClinicFrame{
    [self reCalculateTableContentHeightReLayout:YES];
}

- (void)reCalculateTableContentHeightReLayout:(BOOL)needLayout{
    CGRect frame = tableClinicAccount.frame;
    tableClinicAccount.frame = CGRectMake(frame.origin.x, frame.origin.y, frame.size.width, [self calculateTableClinicHeight]);
    [accordionView setOriginalSize:tableClinicAccount.frame.size forIndex:1 relayout:needLayout];
}

- (float)calculateTableClinicHeight{
    if (self.standardProfile && self.standardProfile.listClinicAccount.count > 0) {
        float height = ClinicCellHeightExpanding;
        for (ClinicAccount *acc in self.standardProfile.listClinicAccount) {
            height += ([_dictExpanding[acc.clinicId] boolValue] ? ClinicCellHeightExpanding : ClinicCellHeightCollapsed);
        }
        return height;
    }
    return ClinicCellHeightExpanding;
}

- (float)calculateTableClinicHeightAtRow:(NSInteger)row{
    if (self.standardProfile && self.standardProfile.listClinicAccount.count > 0) {
        float height = ClinicCellHeightExpanding;
        int index = 0;
        for (ClinicAccount *acc in self.standardProfile.listClinicAccount) {
            if (index >= row) {
                break;
            }
            index++;
            height += ([_dictExpanding[acc.clinicId] boolValue] ? ClinicCellHeightExpanding : ClinicCellHeightCollapsed);
        }
        return height;
    }
    return ClinicCellHeightExpanding;
}

#pragma mark - Initialize Profile For Adult

- (void)initializeProfileView {
    [self.viewProfile setBackgroundColor:[UIColor whiteColor]];
    
    accordionView = [[AccordionView alloc] initWithFrame:CGRectMake(0.0, 0.0, SCREEN_WIDTH, SCREEN_HEIGHT)];
    accordionView.delegate = self;
    [accordionView setAllowsMultipleSelection:NO];
    [accordionView setAllowsEmptySelection:YES];
    [self.viewProfile addSubview:accordionView];
    
    [self.txtAddress setTextColor:PHR_COLOR_GRAY];
    [self.txtBirthday setTextColor:PHR_COLOR_GRAY];
    [self.txtCity setTextColor:PHR_COLOR_GRAY];
    [self.txtName setTextColor:PHR_COLOR_GRAY];
    [self.txtNameKana setTextColor:PHR_COLOR_GRAY];
//    [self.txtNickname setTextColor:PHR_COLOR_GRAY];
    [self.txtOccupation setTextColor:PHR_COLOR_GRAY];
    [self.txtPrefecture setTextColor:PHR_COLOR_GRAY];
    [self.txtZipCode setTextColor:PHR_COLOR_GRAY];
    
    /* -------- First View In ProfileVC -------- */
    UIButton *header1 = [[UIButton alloc] initWithFrame:CGRectMake(0, 0, 0, 30)];
    [self setupToButtonOnViewDropDown:header1 withTitle:kLocalizedString(kProfile)];
    UIView *viewInfo = [self setupToProfileViewTab];
    
    [accordionView addHeader:header1 withView:viewInfo];
    
    /* -------- Second View In ProfileVC -------- */
    btnAddAccLinked = [[UIButton alloc] initWithFrame:CGRectMake(0, 0, 0, 30)];
    if (self.standardProfile.listClinicAccount.count == 0) {
        [self setupToButtonOnViewDropDown:btnAddAccLinked withTitle:kLocalizedString(kLinkedClinicAccounts)];
    }
    else {
        [self setupToButtonOnViewDropDown:btnAddAccLinked withTitle:[NSString stringWithFormat:@"%@ (%.0lu)", kLocalizedString(kLinkedClinicAccounts), (unsigned long)self.standardProfile.listClinicAccount.count]];
    }
    
    // Add table clinic account
    [self addTableClinicAccount];
    
    [accordionView setNeedsLayout];
}

- (void)addTableClinicAccount  {
    tableClinicAccount = [[UITableView alloc] initWithFrame:CGRectMake(0, 0, SCREEN_WIDTH, [self calculateTableClinicHeight])];
    tableClinicAccount.delegate = self;
    tableClinicAccount.dataSource = self;
    [tableClinicAccount setScrollEnabled:NO];
    [tableClinicAccount setBackgroundColor:[UIColor clearColor]];
    [tableClinicAccount setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    [tableClinicAccount registerNib:[UINib nibWithNibName:NSStringFromClass([LinkedAcccountTableViewCell class]) bundle:nil] forCellReuseIdentifier:LinkedAccCellIdentifier];
    [tableClinicAccount setClipsToBounds:NO];
    // Add to according view
    [accordionView addHeader:btnAddAccLinked withView:tableClinicAccount];
}

- (void)setTitleToLinkedAcc:(NSNotificationCenter *)notification {
    if (self.standardProfile.listClinicAccount.count == 0) {
        [btnAddAccLinked setTitle:kLocalizedString(kLinkedClinicAccounts) forState:UIControlStateNormal];
    }
    else {
        [btnAddAccLinked setTitle:[NSString stringWithFormat:@"%@ (%.0lu)", kLocalizedString(kLinkedClinicAccounts), (unsigned long)self.standardProfile.listClinicAccount.count] forState:UIControlStateNormal];
    }
}

#pragma mark - TableView Data Source - Delegate

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Return the number of rows in the section.
    return (self.standardProfile.listClinicAccount.count + 1);
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row > 0) {
        ClinicAccount *acc = self.standardProfile.listClinicAccount[indexPath.row - 1];
        if (_dictExpanding[acc.clinicId] && [_dictExpanding[acc.clinicId] boolValue]) {
            return ClinicCellHeightExpanding;
        }
        else{
            return ClinicCellHeightCollapsed;
        }
    }
    return ClinicCellHeightExpanding;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    __block LinkedAcccountTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:LinkedAccCellIdentifier];
    if (cell == nil) {
        cell = [[LinkedAcccountTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:LinkedAccCellIdentifier];
        [cell setBackgroundColor:[UIColor clearColor]];
    }
    [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
    [cell setCellExpandedAction:^(NSString * clinicId){
        _dictExpanding[clinicId] = _dictExpanding[clinicId] ? @(![_dictExpanding[clinicId] boolValue]) : @(YES);
        
        [tableClinicAccount reloadData];
        
        
        
        if ([_dictExpanding[clinicId] boolValue]) {
            [self reCalculateTableContentHeightReLayout:NO];
            [accordionView scrollToPosition:[self calculateTableClinicHeightAtRow:indexPath.row] ofView:tableClinicAccount cellHeight:ClinicCellHeightExpanding];
        }
        else{
            [self reloadTableClinicFrame];
        }
    }];
    
    [cell setCellSearchAction:^(){
        SearchHospitalViewController *controller = [[SearchHospitalViewController alloc] initWithNibName:NSStringFromClass([SearchHospitalViewController class]) bundle:nil];
        [controller setActionSelectHospital:^(ClinicHospital *hospital){
            _selectedHospital = hospital;
            [tableClinicAccount reloadData];
        }];
        [self.navigationController pushViewController:controller animated:YES];
    }];
    
    [cell setCellSaveAction:^(NSString *name, NSString *hospCode, NSString *pass){
        if (name.length > 128 || hospCode.length > 35) {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
            return;
        }
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestAddClinicAccountName:name hospCode:hospCode pass:pass profileId:self.standardProfile.profileId completed:^(id response){
            [PHRAppDelegate hideLoading];
            if (response && response[KEY_Content] != [NSNull null]) {
                ClinicAccount *acc = [[ClinicAccount alloc] initWithDict:response[KEY_Content]];
                [self.standardProfile.listClinicAccount addObject:acc];
                [tableClinicAccount reloadData];
                [self reloadTableClinicFrame];
                [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kAddAccountSuccessfully)];
                
                
                // clear data
                _selectedHospital = nil;
                _needToClearFirstCell = YES;
                
            }
            else{
                [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kAddAccountFail)];
            }
        } error:^(NSString *error){
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kAddAccountFail)];
        }];
    }];
    
    [cell setCellDeleteAction:^(NSString *clinicId){
        [self confirmDeleteClinic:clinicId];
    }];
    
    [cell setCellSetActiveAction:^(NSString *clinicId){
        [[PHRClient instance] requestSetActiveClinicAccount:clinicId profileId:self.standardProfile.profileId completed:^(id response){
            for (ClinicAccount *acc in self.standardProfile.listClinicAccount) {
                acc.activeFlag = NO;
                if ([acc.clinicId isEqualToString:clinicId]) {
                    acc.activeFlag = YES;
                }
            }
            [tableClinicAccount reloadData];
        }error:^(NSString *error){
        }];
    }];
    
    if (indexPath.row == 0) {
        [cell setupWithState:ClinicCellStateAddNew expanded:YES];
        [cell setupInfoWithHospital:_selectedHospital];
        if (_needToClearFirstCell) {
            [cell clearData];
            _needToClearFirstCell = NO;
        }
    }
    else{
        ClinicAccount *acc = [self.standardProfile.listClinicAccount objectAtIndex:(indexPath.row - 1)];
        [cell setupWithState:ClinicCellStateActived expanded:[_dictExpanding[acc.clinicId] boolValue]];
        [cell setupInfoWithAccount:acc];
    }
    
    return cell;
}

- (void)confirmDeleteClinic:(NSString*)clinic {
    _selectedClinicId = clinic;
    UIAlertView *alert = [[UIAlertView alloc]initWithTitle:kLocalizedString(kDeleteAccountConfirm) message:@"" delegate:self cancelButtonTitle:kLocalizedString(kOK) otherButtonTitles:kLocalizedString(kCancel), nil];
    alert.tag = 301;
    dispatch_async(dispatch_get_main_queue(), ^{
        [alert show];
    });
}

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex{
    if (alertView.tag == 301 && buttonIndex == 0 && _selectedClinicId) {
        // delete
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestDeleteClinicAccount:_selectedClinicId profileId:self.standardProfile.profileId completed:^(id response){
            [PHRAppDelegate hideLoading];
            [self.standardProfile removeClinicAccountId:_selectedClinicId];
            [tableClinicAccount reloadData];
            [self reloadTableClinicFrame];
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kDeleteAccountSuccessfully)];
        }error:^(NSString *error){
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kDeleteAccountFail)];
        }];
    }
}


#pragma mark - Public Methods

- (void)setupToButtonOnViewDropDown:(UIButton *)btn withTitle:(NSString *)titleBtn {
    [btn setTitle:titleBtn forState:UIControlStateNormal];
    [btn.titleLabel setFont:[FontUtils aileronRegularWithSize:14.0]];
    [btn setTitleColor:RGBCOLOR(75.0, 75.0, 75.0) forState:UIControlStateNormal];
    [btn setBackgroundImage:[UIImage imageNamed:@"BtnProfile"] forState:UIControlStateNormal];
    btn.contentHorizontalAlignment = UIControlContentHorizontalAlignmentLeft;
    btn.contentEdgeInsets = UIEdgeInsetsMake(0, 10, 0, 0);
    
    UIImageView *arrow = [[UIImageView alloc] initWithFrame:CGRectMake(SCREEN_WIDTH - 25.0, btn.frame.size.height / 2 - 3.0, 8.0, 8.0)];
    arrow.image = [UIImage imageNamed:@"ArrowDown"];
    [btn addSubview:arrow];
}

- (UIView *)setupToProfileViewTab {
    UIView *viewInfo = [[UIView alloc] initWithFrame:CGRectMake(0.0, 0.0, SCREEN_WIDTH, 325.0)];
    [viewInfo setBackgroundColor:[UIColor clearColor]];
    
    self.txtName = [[PHRTextField alloc] initCusTomTextField];
    [self.txtName setFrame:CGRectMake(10.0, 20.0, (SCREEN_WIDTH - 20 ) /2, 30)];
    self.txtName.placeholder = kLocalizedString(kName);
    self.txtName.delegate = self;
    [viewInfo addSubview:self.txtName];
    
//    self.txtNickname = [[PHRTextField alloc] initCusTomTextField];
//    [self.txtNickname setFrame:CGRectMake(10.0, 60.0, (SCREEN_WIDTH - 20 ) /2, 30)];
//    self.txtNickname.delegate = self;
//    self.txtNickname.placeholder = kLocalizedString(kNickname);
//    [viewInfo addSubview:self.txtNickname];
    self.comboboxGender = [[PHRButtonCombobox alloc] initWithFrame:CGRectMake(10.0, 120.0, (SCREEN_WIDTH - 30 ) /2, 30)];
    [self.comboboxGender setArrayChoices:[NSArray arrayWithObjects:kLocalizedString(kSignUpMale), kLocalizedString(kSignUpFemale), nil]];
    [viewInfo addSubview:self.comboboxGender];
    
    UIView *viewContainCamera = [[UIView alloc] initWithFrame:CGRectMake(SCREEN_WIDTH - 10.0 - (SCREEN_WIDTH - 30 ) / 4, 20.0, (SCREEN_WIDTH - 30 ) /4, (SCREEN_WIDTH - 30 ) /4)];
    [viewContainCamera setBackgroundColor:RGBCOLOR(245.0, 245.0, 245.0)];
    [viewContainCamera.layer setBorderWidth:1.0];
    [viewContainCamera.layer setBorderColor:[UIColor lightGrayColor].CGColor];
    viewContainCamera.clipsToBounds = YES;
    
    self.imgAvatar = [[UIImageView alloc] initWithFrame:CGRectMake(0.0, 0.0, (SCREEN_WIDTH - 30 ) /4, (SCREEN_WIDTH - 30 ) /4)];
    self.imgAvatar.image = [UIImage imageNamed:@"IconCamera"];
    [self.imgAvatar setContentMode:UIViewContentModeScaleAspectFill];
    [viewContainCamera addSubview:self.imgAvatar];
    [viewInfo addSubview:viewContainCamera];
    
    self.btnCamera = [UIButton buttonWithType:UIButtonTypeRoundedRect];
    [self.btnCamera setFrame:CGRectMake(0.0, 0.0, (SCREEN_WIDTH - 30 ) / 4, (SCREEN_WIDTH - 30 ) / 4)];
    [self.btnCamera addTarget:self action:@selector(actionToCamera:) forControlEvents:UIControlEventTouchUpInside];
    [viewContainCamera addSubview:self.btnCamera];
    
    self.txtNameKana = [[PHRTextField alloc] initCusTomTextField];
    [self.txtNameKana setFrame:CGRectMake(10.0, 60.0, (SCREEN_WIDTH - 20 ) /2, 30)];
    self.txtNameKana.delegate = self;
    self.txtNameKana.placeholder = kLocalizedString(kNameKana);
    [viewInfo addSubview:self.txtNameKana];
    
    self.txtBirthday = [[PHRTextField alloc] initCusTomTextField];
    self.txtBirthday.frame = CGRectMake(SCREEN_WIDTH / 2 + 5.0, 120.0, (SCREEN_WIDTH - 30 ) /2, 30);
    self.txtBirthday.enabled = NO;
    self.txtBirthday.placeholder = kLocalizedString(kBirthday);
    [viewInfo addSubview:self.txtBirthday];
    
    UIButton *btnBirthday = [[UIButton alloc] initWithFrame:self.txtBirthday.frame];
    [btnBirthday setBackgroundColor:[UIColor clearColor]];
    [btnBirthday addTarget:self action:@selector(actionChangeBirthday:) forControlEvents:UIControlEventTouchUpInside];
    [viewInfo addSubview:btnBirthday];
    
    self.txtZipCode = [[PHRTextField alloc] initCusTomTextField];
    self.txtZipCode.frame = CGRectMake(10.0, 160.0, (SCREEN_WIDTH - 30 ) /2, 30);
    self.txtZipCode.delegate = self;
    self.txtZipCode.placeholder = kLocalizedString(kZipCode);
    [self.txtZipCode setKeyboardType:UIKeyboardTypeNumberPad];
    [viewInfo addSubview:self.txtZipCode];
    
    self.txtPrefecture = [[PHRTextField alloc] initCusTomTextField];
    self.txtPrefecture.delegate = self;
    self.txtPrefecture.frame = CGRectMake(SCREEN_WIDTH / 2 + 5.0, 160.0, (SCREEN_WIDTH - 30 ) /2, 30);
    self.txtPrefecture.placeholder = kLocalizedString(kPrefecture);
    [viewInfo addSubview:self.txtPrefecture];
    
    self.txtCity = [[PHRTextField alloc] initCusTomTextField];
    self.txtCity.delegate = self;
    self.txtCity.frame = CGRectMake(10.0, 200.0, (SCREEN_WIDTH - 20), 30);
    self.txtCity.placeholder = kLocalizedString(kCity);
    [viewInfo addSubview:self.txtCity];
    
    self.txtAddress = [[PHRTextField alloc] initCusTomTextField];
    self.txtAddress.delegate = self;
    self.txtAddress.frame = CGRectMake(10.0, 240.0, (SCREEN_WIDTH - 20), 30);
    self.txtAddress.placeholder = kLocalizedString(kAddress);
    [viewInfo addSubview:self.txtAddress];
    
    self.txtOccupation = [[PHRTextField alloc] initCusTomTextField];
    self.txtOccupation.delegate = self;
    self.txtOccupation.frame = CGRectMake(10.0, 280.0, (SCREEN_WIDTH - 20), 30);
    
    [viewInfo addSubview:self.txtOccupation];
    
    [arrayTextProfileInfo addObject:self.txtName];
//    [arrayTextProfileInfo addObject:self.txtNickname];
    [arrayTextProfileInfo addObject:self.comboboxGender];
    [arrayTextProfileInfo addObject:self.txtNameKana];
    [arrayTextProfileInfo addObject:self.txtBirthday];
    [arrayTextProfileInfo addObject:self.txtAddress];
    [arrayTextProfileInfo addObject:self.txtCity];
    [arrayTextProfileInfo addObject:self.txtOccupation];
    [arrayTextProfileInfo addObject:self.txtPrefecture];
    [arrayTextProfileInfo addObject:self.txtZipCode];
    
    [self.txtBirthday setKeyboardType:UIKeyboardTypeNumberPad];
    [self.txtZipCode setKeyboardType:UIKeyboardTypeNumberPad];
    
    return viewInfo;
}

#pragma mark - Action Of Linked Acc

- (void)actionToSavelinkedAccount:(UIButton *)sender {
    NSIndexPath *indexPath = [NSIndexPath indexPathForRow:sender.tag inSection:0.0];
    LinkedAcccountTableViewCell *cell = [tableClinicAccount cellForRowAtIndexPath:indexPath];
    
    if ([cell.txtLinkedAcc.text isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissUserName)];
        return;
    }
    if ([cell.txtLinkedAccPassword.text isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissPassword)];
        return;
    }
    
    ClinicAccount *accLinked = [ClinicAccount new];
    accLinked.patientCode = cell.txtLinkedAcc.text;
    accLinked.password = cell.txtLinkedAccPassword.text;
    
    [self.standardProfile.listClinicAccount addObject:accLinked];
    [[NSNotificationCenter defaultCenter] postNotificationName:ChangeTitleAccLinked object:nil];
    [tableClinicAccount reloadData];
}

- (void)actionToSaveCurrentLinkedAccount:(UIButton *)sender {
    NSIndexPath *indexPath = [NSIndexPath indexPathForRow:sender.tag inSection:0.0];
    LinkedAcccountTableViewCell *cell = [tableClinicAccount cellForRowAtIndexPath:indexPath];
    
    if ([cell.txtLinkedAcc.text isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissUserName)];
        return;
    }
    if ([cell.txtLinkedAccPassword.text isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissPassword)];
        return;
    }
    
    ClinicAccount *accLinked = [self.standardProfile.listClinicAccount objectAtIndex:(sender.tag - 1)];
    accLinked.patientCode = cell.txtLinkedAcc.text;
    accLinked.password = cell.txtLinkedAccPassword.text;
    
    [tableClinicAccount reloadData];
}

#pragma mark - Method To Left Menu Bar Item

- (BOOL)checkRequire {
    // name
    if (!self.txtName.text || [self.txtName.text isEqualToString:@""]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissEmail)];
        return NO;
    }
    
    // name kana
    if (!self.txtNameKana.text || [self.txtNameKana.text isEqualToString:@""]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kNameKanaInvalid)];
        return NO;
    }
    
    // Birthday
    if (!self.txtBirthday || [self.txtBirthday.text isEqualToString:@""]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kPleaseEnterBirthday)];
        return NO;
    }
    
    if (self.txtName.text.length > 30 || self.txtNameKana.text.length > 30 || self.txtZipCode.text.length > 10 || self.txtPrefecture.text.length > 35 || self.txtCity.text.length > 64 || self.txtAddress.text.length > 255 || self.txtOccupation.text.length > 35) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
        return NO;
    }
    return YES;
}

- (void)collectProfile {
    if (!self.standardProfile) {
        _standardProfile = [[ProfileStandard alloc] init];
    }
    self.standardProfile.name = self.txtName.text;
//    self.standardProfile.nickName = self.txtNickname.text;
    self.standardProfile.gender = [self.comboboxGender getText]; // gender
    self.standardProfile.nameKana = self.txtNameKana.text;
    self.standardProfile.zipCode = self.txtZipCode.text;
    self.standardProfile.prefecture = self.txtPrefecture.text;
    self.standardProfile.city = self.txtCity.text;
    self.standardProfile.address = self.txtAddress.text;
    if (self.standardProfile && self.standardProfile.profileId && self.standardProfile.isMainProfile) {
         self.standardProfile.occupation = self.txtOccupation.text;
    } else {
         self.standardProfile.relationship = self.txtOccupation.text;
    }
    self.standardProfile.occupation = self.txtOccupation.text;
    self.standardProfile.isActive = NO;
    self.standardProfile.birthday = [self dateFromBirthdayField];
}

- (void)actionNavigationBarItemRight {
    if (![self checkRequire]) {
        return;
    }
    [self collectProfile];
    // Call API
    // @LuongLH Temporary comment because server upload error
    [PHRAppDelegate showLoading];
    if (self.isChangedAvatar) {
        [self usingNSOperationQueueToUploadImage:self.imgAvatar.image];
    }
    else{
        [self requestUpdateProfile];
    }
}

#pragma mark - Action Change Avatar

- (void)actionToCamera:(id)sender {
  [NSUtils createPhotoLibrary:self andViewController:self];
}

#pragma mark -  Methods
- (void)assetsPickerController:(CTAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets {
    PHImageRequestOptions *requestOptions = [[PHImageRequestOptions alloc] init];
    requestOptions.resizeMode   = PHImageRequestOptionsResizeModeExact;
    requestOptions.deliveryMode = PHImageRequestOptionsDeliveryModeHighQualityFormat;
    
    [assets enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
        PHImageManager *manager = [PHImageManager defaultManager];
        CGFloat scale = UIScreen.mainScreen.scale;
        CGSize targetSize = CGSizeMake(self.imgAvatar.frame.size.height * scale, self.imgAvatar.frame.size.height * scale);
        
        [manager ctassetsPickerRequestImageForAsset:assets[0]
                                         targetSize:targetSize
                                        contentMode:PHImageContentModeAspectFill
                                            options:requestOptions
                                      resultHandler:^(UIImage *image, NSDictionary *info){
                                          self.imgAvatar.image = image;
                                          self.isChangedAvatar = YES;
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

- (void)usingNSOperationQueueToUploadImage:(UIImage*)imageFile {
    [self processUploadImageInNewThread: imageFile];
}

- (void)processUploadImageInNewThread:(UIImage*)newImage {
    __weak __typeof(self) weakSelf = self;
    [[PHRClient instance] uploadProfileImageToServer:newImage andCompletion:^(id responseObject) {
        if (responseObject == nil) {
            dispatch_async(dispatch_get_main_queue(), ^{
                [PHRAppDelegate hideLoading];
                [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
            });
        }
        else {
            _standardProfile.avatar = [Validator getSafeString:responseObject[@"content"]];
            [weakSelf requestUpdateProfile];
        }
    }];
}

- (void)requestUpdateProfile {
    if (self.isEditMode) {
        [[PHRClient instance] requestEditStandardProfile:_standardProfile completed:^(id response){
            [PHRAppDelegate hideLoading];
            if (response && response[KEY_Content] != [NSNull null]) {
                for (ProfileStandard *profile in PHRAppStatus.arrayStandardProfile) {
                    if ([profile.profileId isEqualToString:_standardProfile.profileId]) {
                        [profile updateWithDictionary:response[KEY_Content]];
                        break;
                    }
                }
            }
            [self.navigationController popViewControllerAnimated:YES];
        } error:^(NSString *error){
            [PHRAppDelegate hideLoading];
        }];
    }
    else{
        [[PHRClient instance] requestAddNewStandardProfile:_standardProfile completed:^(id response){
            [PHRAppDelegate hideLoading];
            // Add new profile
            if (response && response[KEY_Content] != [NSNull null]) {
                ProfileStandard *standardProfile = [[ProfileStandard alloc] initWithDictionary:response[KEY_Content]];
                [PHRAppStatus addNewStandardProfile:standardProfile];
            }
            [self.navigationController popViewControllerAnimated:YES];
        } error:^(NSString *error){
            [PHRAppDelegate hideLoading];
        }];
    }
}

#pragma mark - AccordionView Delegate

- (void)accordion:(AccordionView *)accordion didChangeSelection:(NSIndexSet *)selection {
    if (selection.count == 0) {
        //hide
    }
    else {
        //
    }
    
    for (PHRTextField *obj in arrayTextProfileInfo) {
        [obj resignFirstResponder];
    }
}

#pragma mark - TextField Delegate

- (BOOL)textFieldShouldReturn:(UITextField *)textField {
    [textField resignFirstResponder];
    return YES;
}

- (void)textFieldDidBeginEditing:(UITextField *)textField {
    BOOL isShow = YES;
    for (UITextField *objText in arrayTextProfileInfo) {
        if (objText == textField) {
            isShow = NO;
        }
    }
    if (isShow) {
        [self animateViewWithDistance:160.0f up:YES];
    }
}

- (void)textFieldDidEndEditing:(UITextField *)textField {
    BOOL isShow = YES;
    for (UITextField *objText in arrayTextProfileInfo) {
        if (objText == textField) {
            isShow = NO;
        }
    }
    if (isShow) {
        [self animateViewWithDistance:160.0f up:NO];
    }
}

- (void)animateViewWithDistance:(float)distance up:(BOOL) up {
    const int movementDistance = distance;
    const float movementDuration = 0.3f;
    
    int movement = (up ? -movementDistance : movementDistance);
    
    [UIView beginAnimations: @"anim" context: nil];
    [UIView setAnimationBeginsFromCurrentState: YES];
    [UIView setAnimationDuration: movementDuration];
    self.view.frame = CGRectOffset(self.view.frame, 0, movement);
    [UIView commitAnimations];
}

- (void)dealloc {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

#pragma mark - action ui
- (void)actionChangeBirthday:(id)sender {
    [self.view endEditing:YES];
    
    // Date picker
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:kLocalizedString(kBirthday) delegate:self];
    [picker setTag:1];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDatePicker];
    [picker setDate:(_standardProfile.birthday ? _standardProfile.birthday :[self getDefaultDate])];
    
    [picker setMaximumDate:[NSDate date]];
    [picker show];
}

- (NSDate*) getDefaultDate {
    NSDate *currentDate = [NSDate date];
    NSUInteger componentFlags = NSCalendarUnitYear;
    NSDateComponents *components = [[NSCalendar currentCalendar] components:componentFlags fromDate:currentDate];
    [components setYear:-35];
    return  [[NSCalendar currentCalendar] dateByAddingComponents:components toDate:currentDate  options:0];
}

#pragma mark - Action sheet date picker delegate
// Action sheet date picker delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date {
    if (self.txtBirthday && date) {
        [self.txtBirthday setText:[self updateTime:date]];
    }
    if (_standardProfile) {
        _standardProfile.birthday = date;
    }
}

#pragma mark - Proccess for birthday date
- (NSString*)textBirthdayFromDate:(NSDate*)date {
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    NSCalendar *calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
    [formatter setCalendar:calendar];
    return [formatter stringFromDate:date];
   

}

- (NSString*)updateTime:(NSDate *)date {
    if (!date) {
        return @"";
    }
    NSString *titleString = [UIUtils stringDate:date withFormat:PHR_BIRTHDAY_SERVER_FORMAT];

    return titleString;
}

- (NSDate*)dateFromBirthdayField {
    if (self.txtBirthday) {
        NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
        [formatter setDateFormat:PHR_BIRTHDAY_SERVER_FORMAT];
        NSCalendar *calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
        [formatter setCalendar:calendar];
        return [formatter dateFromString:self.txtBirthday.text];
    }
    return nil;
}


@end
