//
//  SearchHospitalViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "SearchHospitalViewController.h"
#import "SearchHospitalCell.h"
#import "IQActionSheetPickerView.h"

@interface SearchHospitalViewController () <IQActionSheetPickerViewDelegate>{
    NSMutableArray *_listResult;
    ClinicHospital *selectedItem;
    NSArray *_arrayCountry;
}

@end

@implementation SearchHospitalViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupNavigationBarTitle:kLocalizedString(kProfile) titleIcon:kLocalizedString(kLinkedClinicAccounts) rightItem:nil];
    float borderWidth = 0.7;
    
    self.txtName.layer.borderColor = [[UIColor lightGrayColor] CGColor];
    self.txtName.layer.borderWidth = borderWidth;
    self.txtName.leftViewMode = UITextFieldViewModeAlways;
    UIImageView *image = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 30, 30)];
    image.contentMode = UIViewContentModeCenter;
    [image setImage:[UIImage imageNamed:@"icon_search.png"]];
    self.txtName.leftView = image;
    self.txtName.placeholder = kLocalizedString(kSearchByName);
    
    self.txtAddress.layer.borderColor = [[UIColor lightGrayColor] CGColor];
    self.txtAddress.layer.borderWidth = borderWidth;
    self.txtAddress.leftViewMode = UITextFieldViewModeAlways;
    UIImageView *image2 = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 30, 30)];
    image2.contentMode = UIViewContentModeCenter;
    [image2 setImage:[UIImage imageNamed:@"icon_location.png"]];
    self.txtAddress.leftView = image2;
    self.txtAddress.placeholder = kLocalizedString(kAddress);
    
    self.txtPhone.layer.borderColor = [[UIColor lightGrayColor] CGColor];
    self.txtPhone.layer.borderWidth = borderWidth;
    self.txtPhone.leftViewMode = UITextFieldViewModeAlways;
    UIImageView *image3 = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 30, 30)];
    image3.contentMode = UIViewContentModeCenter;
    [image3 setImage:[UIImage imageNamed:@"icon_phone.png"]];
    self.txtPhone.leftView = image3;
    self.txtPhone.placeholder = kLocalizedString(kPhone);
    
    UIImageView *image4 = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 30, 30)];
    image4.contentMode = UIViewContentModeCenter;
    [image4 setImage:[UIImage imageNamed:@""]];
    self.txtCountry.layer.borderColor = [[UIColor lightGrayColor] CGColor];
    self.txtCountry.layer.borderWidth = borderWidth;
    self.txtCountry.leftViewMode = UITextFieldViewModeAlways;
    self.txtCountry.leftView = image4;
    self.txtCountry.placeholder = kLocalizedString(kCountry);
    _arrayCountry = @[kLocalizedString(kAll), kLocalizedString(kVietnam), kLocalizedString(kJapan)];
    
    [self.btnSearch setTitle:kLocalizedString(kSearchNow) forState:UIControlStateNormal];
    [self.btnOk setTitle:kLocalizedString(kOK) forState:UIControlStateNormal];
    
    [self.tableResult registerNib:[UINib nibWithNibName:NSStringFromClass([SearchHospitalCell class]) bundle:nil] forCellReuseIdentifier:NSStringFromClass([SearchHospitalCell class])];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)actionSearch:(id)sender {
    [PHRAppDelegate showLoading];
    NSString *country = [self.txtCountry.text isEqualToString:_arrayCountry[0]] ? nil : self.txtCountry.text;
    [[PHRClient instance] requestSearchHospitalWithName:self.txtName.text address:self.txtAddress.text tel:self.txtPhone.text country:country completed:^(id response){
        [PHRAppDelegate hideLoading];
        _listResult = nil;
        _listResult = [[NSMutableArray alloc] init];
        NSArray *array = response[KEY_Content];
        if ([array isKindOfClass:[NSArray class]] && array.count > 0) {
            for (NSDictionary *dict in array) {
                ClinicHospital *hos = [[ClinicHospital alloc] initWithDict:dict];
                [_listResult addObject:hos];
            }
        }
        else{
            // Search return no data with this keyword
            [NSUtils showMessage:kLocalizedString(@"Can not find any result") withTitle:APP_NAME];
        }
        [self.tableResult reloadData];
    }error:^(NSString *error){
        [PHRAppDelegate hideLoading];
    }];
}

- (IBAction)actionDone:(id)sender {
    if (self.actionSelectHospital) {
        self.actionSelectHospital(selectedItem);
    }
    [self.navigationController popViewControllerAnimated:YES];
}

- (IBAction)actionSelectCountry:(id)sender {
    // Close keyboard before open date picker
    [self.view endEditing:YES];
    // Date picker
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
    [picker setTag:1];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleTextPicker];
    [picker setTitlesForComponenets:[NSArray arrayWithObject:_arrayCountry]];
    [picker show];
}

#pragma mark - table delegate
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return _listResult.count;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{
    return 90;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath{
    SearchHospitalCell *cell = (SearchHospitalCell*)[tableView dequeueReusableCellWithIdentifier:NSStringFromClass([SearchHospitalCell class])];
    if (!cell) {
        cell = [[SearchHospitalCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:NSStringFromClass([SearchHospitalCell class])];
        [cell setBackgroundColor:[UIColor clearColor]];
    }
    ClinicHospital *hos = _listResult[indexPath.row];
    [cell fillInfoName:hos.hospitalName address:hos.address tel:hos.tel];
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    selectedItem = _listResult[indexPath.row];
}

#pragma mark - Action sheet delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectTitles:(NSArray *)titles {
    if (!titles && titles.count <= 0) {
        return;
    }
    self.txtCountry.text = titles[0];
}



@end
