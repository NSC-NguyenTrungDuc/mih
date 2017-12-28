//
//  BluetoothDeviceConnectViewController.m
//  PHR
//
//  Created by BillyMobile on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BluetoothDeviceConnectViewController.h"
#import "OldDeviceTableViewCell.h"
#import "NewDeviceTableViewCell.h"
#import "BluetoothDeviceHeader.h"
#import "ProfileListViewController.h"

@interface BluetoothDeviceConnectViewController (){
}

@end

static NSString *OldDeviceCell = @"oldDeviceCell";
static NSString *NewDeviceCell = @"newDeviceCell";

@implementation BluetoothDeviceConnectViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupNavigationBarTitle:@"Bluetooth" titleIcon:nil rightItem:kLocalizedString(@"Load")];
    self.tableViewContent.delegate = self;
    self.tableViewContent.dataSource = self;
    
    [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([OldDeviceTableViewCell class]) bundle:nil] forCellReuseIdentifier:OldDeviceCell];
    [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([NewDeviceTableViewCell class]) bundle:nil] forCellReuseIdentifier:NewDeviceCell];
    [[BluetoothManager instance] setDisconnectDeviceCallBack:^(CBPeripheral *peripheral){
        [self.tableViewContent reloadData];
    }];

    // Do any additional setup after loading the view from its nib.
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    // Register notification
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleBluetoothScanDevice:) name:kNotifyBlueScanNewDevice object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleBluetoothDisconnect:) name:kNotifyBlueDisconnectDevice object:nil];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)actionNavigationBarItemRight {
    //we will search for devices that contain the service that our device is programmed to have
    [[BluetoothManager instance].scannedDevices removeAllObjects];
    [[BluetoothManager instance] beginScanDevice];
    [[BluetoothManager instance] setFindDeviceCallBack:^(CBPeripheral *peripheral){
        [self.tableViewContent reloadData];
    }];
    
    [self.tableViewContent reloadData];

    //we are going to trigger a NSTimer to stop scanning after 5 seconds
    [NSTimer scheduledTimerWithTimeInterval:5.0 target:self selector:@selector(stopScan:) userInfo:nil repeats:NO];
}

- (void) stopScan:(id)sender{
    NSTimer *timer = (NSTimer *)sender;
    [timer invalidate];
    [[BluetoothManager instance].manager stopScan];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    if([BluetoothManager instance].availableConnectedDevices != nil && (id) [BluetoothManager instance].availableConnectedDevices != [NSNull null]){
        return 2;
    }
    return 0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if(section == 0){
        return [[BluetoothManager instance].allConnectedDevices count];
    }else{
        return [[BluetoothManager instance].scannedDevices count];
    }
    
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if(indexPath.section == 0){
        BluetoothDevice *device = [[BluetoothManager instance].allConnectedDevices objectAtIndex:indexPath.row];
        OldDeviceTableViewCell *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:OldDeviceCell forIndexPath:indexPath];
        cell.lblDeviceName.text = device.deviceName;
        cell.lblUserName.text = device.userName;
        
        if([[BluetoothManager instance].availableConnectedDevices count]>0){
            for(CBPeripheral *pre in [BluetoothManager instance].availableConnectedDevices){
                if([device.deviceID isEqualToString:[pre.identifier UUIDString]]){
                    cell.lblStatus.text = kLocalizedString(@"Connected");
                    [cell setDeleteCallBack:^(){
                        [pre setDelegate:nil];
                        [[BluetoothManager instance].scannedDevices addObject:pre];
                        [[BluetoothManager instance].availableConnectedDevices removeObject:pre];
                        [[BluetoothManager instance] removeToDB:device];
                        [self.tableViewContent reloadData];
                    }];
                }else{
                    cell.lblStatus.text = kLocalizedString(@"Not Connected");
                    [cell setDeleteCallBack:^(){
                        [[BluetoothManager instance] removeToDB:device];
                        [self.tableViewContent reloadData];
                    }];

                }
            }
        }else{
            cell.lblStatus.text = kLocalizedString(@"Not Connected");
            [cell setDeleteCallBack:^(){
                [[BluetoothManager instance] removeToDB:device];
                [self.tableViewContent reloadData];
            }];
        }
        
        return cell;
    }else{
        CBPeripheral *peripheral = [[BluetoothManager instance].scannedDevices objectAtIndex:indexPath.row];
        NewDeviceTableViewCell *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:NewDeviceCell forIndexPath:indexPath];
        cell.lblDeviceName.text = peripheral.name;
        return cell;
    }
    
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{
    if(indexPath.section == 0){
        return 60;
    }else{
        return 50;
    }
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    if(indexPath.section == 0){
        
    }else{ // only select new device
        
        CBPeripheral *peripheral = [[BluetoothManager instance].scannedDevices objectAtIndex:indexPath.row];
        if(peripheral != nil){
            // Pair with device
            [[BluetoothManager instance].manager connectPeripheral:peripheral options:nil];
            
            ProfileListViewController *profileController = [[ProfileListViewController alloc] initWithNibName:NSStringFromClass([ProfileListViewController class]) bundle:nil];
            
            [profileController setAddProfileCallBack:^(Profile* profile){
                
                [[BluetoothManager instance].availableConnectedDevices addObject:peripheral];
                [[BluetoothManager instance].scannedDevices removeObject:peripheral];
                [[BluetoothManager instance] saveToDB:peripheral forProfile:profile];
                [self.tableViewContent reloadData];
            }];
            
            [self.navigationController pushViewController:profileController animated:YES];
            //
            //            [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleBluetoothConnect:) name:kNotifyBlueConnectDevice object:nil];
            
        }
        
    }
}

#pragma mark CBCentral[BluetoothManager instance].managerDelegate

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
    BluetoothDeviceHeader *headerView = [[[NSBundle mainBundle] loadNibNamed:@"BluetoothDeviceHeader" owner:self options:nil] objectAtIndex:0];
    if(section == 0){
        headerView.lblDeviceType.text = kLocalizedString(@"My Device");
    }else{
        headerView.lblDeviceType.text = kLocalizedString(@"Other Device");
    }
    return headerView;
}

- (void)handleBluetoothScanDevice:(NSNotification*)notification{
    [self.tableViewContent reloadData];
}

- (void)handleBluetoothDisconnect:(NSNotification*)notification{
    [self.tableViewContent reloadData];
}

- (void)handleBluetoothConnect:(NSNotification* )notification {
//    CBPeripheral* peripheral = (CBPeripheral*)notification.object;
//    ProfileListViewController *profileController = [[ProfileListViewController alloc] initWithNibName:NSStringFromClass([ProfileListViewController class]) bundle:nil];
//    
//    [profileController setAddProfileCallBack:^(BOOL forBaby){
//        
//        [[BluetoothManager instance].availableConnectedDevices addObject:peripheral];
//        [[BluetoothManager instance].scannedDevices removeObject:peripheral];
//        [[BluetoothManager instance] saveToDB:peripheral forBaby:forBaby];
//        [self.tableViewContent reloadData];
//    }];
//    
//    [self.navigationController pushViewController:profileController animated:YES];
}

#pragma mark UITextField Delegate

- (BOOL)textFieldShouldReturn:(UITextField *)aTextField{
    [aTextField resignFirstResponder];
    return YES;
}

@end
