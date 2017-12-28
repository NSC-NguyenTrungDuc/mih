//
//  HealthDiagnosisViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 10/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "HealthDiagnosisViewController.h"
#import "DiagnosisGroup.h"
#import "DiagnosisFieldText.h"
#import "DiagnosisFieldCombobox.h"

@interface HealthDiagnosisViewController (){
    
}
@property (strong, nonatomic) NSMutableArray *arrayInfo;

@end

@implementation HealthDiagnosisViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    // Setup navigation bar
    [self setupNavigationBarTitle:kLocalizedString(kTitleDiagnosisHealth) titleIcon:@"icon_title_diagnosis" rightItem:kLocalizedString(kSave)];
    
    // Setup view
    [self initDiagnosisView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.imageBackground];
}
//- (void)initDiagnosisView{
//    self.arrayInfo = [[NSMutableArray alloc] init];
//    // Group 1 - Blood
//    DiagnosisFieldText *fieldWBC = [[DiagnosisFieldText alloc] initWithTitle:kLocalizedString(kDiagnosisBloodWBC) placeholder:kLocalizedString(kDiagnosisBloodWBCValue)];
//    DiagnosisFieldText *fieldRBC = [[DiagnosisFieldText alloc] initWithTitle:kLocalizedString(kDiagnosisBloodWBC) placeholder:kLocalizedString(kDiagnosisBloodWBCValue)];
//    DiagnosisFieldText *fieldHb = [[DiagnosisFieldText alloc] initWithTitle:kLocalizedString(kDiagnosisBloodWBC) placeholder:kLocalizedString(kDiagnosisBloodWBCValue)];
//    DiagnosisFieldText *fieldHt = [[DiagnosisFieldText alloc] initWithTitle:kLocalizedString(kDiagnosisBloodWBC) placeholder:kLocalizedString(kDiagnosisBloodWBCValue)];
//    DiagnosisGroup *groupBlood = [[DiagnosisGroup alloc] initWithTitle:kLocalizedString(kTitleDiagnosisGroupBlood) fields:[NSArray arrayWithObjects:fieldWBC, fieldRBC, fieldHb, fieldHt, nil]];
//    [self.arrayInfo addObject:groupBlood];
//    
//    // Group 2 - Sugar
//    
//    
//    
//    [self.tableDiagnosis reloadData];
//}

- (void)initDiagnosisView{
    self.viewAccordion = [[AccordionView alloc] initWithFrame:CGRectMake(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT)];
    self.viewAccordion.delegate = self;
    [self.viewContent addSubview:self.viewAccordion];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeTop];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    [self.viewAccordion.scrollView setShowsVerticalScrollIndicator:NO];
    [self.viewAccordion setAllowsMultipleSelection:YES];
    [self.viewAccordion setAllowsEmptySelection:YES];
    
    // -------------- Group Blood ------------
    UIButton *headerBlood = [self createButtonHeaderWithTitle:kLocalizedString(kTitleDiagnosisGroupBlood)];
    [self.viewAccordion addHeader:headerBlood withView:self.viewGroupBlood];
    
    [self.labelBloodWBC setText:kLocalizedString(kDiagnosisBloodWBC)];
    [self.textBloodWBCValue setPlaceholder:kLocalizedString(kDiagnosisBloodWBCValue)];
    [self.labelBloodRBC setText:kLocalizedString(kDiagnosisBloodRBC)];;
    [self.textBloodRBCValue setPlaceholder:kLocalizedString(kDiagnosisBloodRBCValue)];
    [self.labelBloodHb setText:kLocalizedString(kDiagnosisBloodHb)];
    [self.textBloodHbValue setPlaceholder:kLocalizedString(kDiagnosisBloodHbValue)];
    [self.labelBloodHt setText:kLocalizedString(kDiagnosisBloodHt)];
    [self.textBloodHtValue setPlaceholder:kLocalizedString(kDiagnosisBloodHtValue)];
    
    // -------------- Group Sugar ---------------
    UIButton *headerSugar = [self createButtonHeaderWithTitle:kLocalizedString(kTitleDiagnosisGroupSugar)];
    [self.viewAccordion addHeader:headerSugar withView:self.viewGroupSugar];
    
    [self.labelSugarFasting setText:kLocalizedString(kDiagnosisSugarFasting)];
    [self.textSugarFastingValue setPlaceholder:kLocalizedString(kDiagnosisSugarFastingValue)];
    [self.labelSugarPostprandial setText:kLocalizedString(kDiagnosisSugarPostprandial)];
    [self.textSugarPostprandialValue setPlaceholder:kLocalizedString(kDiagnosisSugarPostprandialValue)];
    [self.labelSugarHbA1c setText:kLocalizedString(kDiagnosisSugarHb1Ac)];
    [self.textSugarHbA1cValue setPlaceholder:kLocalizedString(kDiagnosisSugarHb1AcValue)];
    
    // --------------- Group Lipit ---------------
    UIButton *headerLipit = [self createButtonHeaderWithTitle:kLocalizedString(kTitleDiagnosisGroupLipit)];
    [self.viewAccordion addHeader:headerLipit withView:self.viewGroupLipit];
    
    [self.labelLipitProtein setText:kLocalizedString(kDiagnosisLipitProtein)];
    [self.textLipitProtein setPlaceholder:kLocalizedString(kDiagnosisLipitProteinValue)];
    [self.labelLipitALB setText:kLocalizedString(kDiagnosisLipitALB)];
    [self.textLipitALB setPlaceholder:kLocalizedString(kDiagnosisLipitALBValue)];
    [self.labelLipitGOTAST setText:kLocalizedString(kDiagnosisLipitGOTAST)];
    [self.textLipitGOTAST setPlaceholder:kLocalizedString(kDiagnosisLipitGOTASTValue)];
    [self.labelLipitGPTALT setText:kLocalizedString(kDiagnosisLipitGPTALT)];
    [self.textLipitGPTALT setPlaceholder:kLocalizedString(kDiagnosisLipitGPTALTValue)];
    [self.labelLipitLDH setText:kLocalizedString(kDiagnosisLipitLDH)];
    [self.textLipitLDH setPlaceholder:kLocalizedString(kDiagnosisLipitLDHValue)];
    [self.labelLipitALP setText:kLocalizedString(kDiagnosisLipitALP)];
    [self.textLipitALP setPlaceholder:kLocalizedString(kDiagnosisLipitALPValue)];
    [self.labelLipitGTP setText:kLocalizedString(kDiagnosisLipitGTP)];
    [self.textLipitGTP setPlaceholder:kLocalizedString(kDiagnosisLipitGTPValue)];
    [self.labelLipitZZT setText:kLocalizedString(kDiagnosisLipitZZT)];
    [self.textLipitZZT setPlaceholder:kLocalizedString(kDiagnosisLipitZZTValue)];
    [self.labelLipitTBil setText:kLocalizedString(kDiagnosisLipitTBil)];
    [self.textLipitTBil setPlaceholder:kLocalizedString(kDiagnosisLipitTBilValue)];
    [self.labelLipitHBs setText:kLocalizedString(kDiagnosisLipitHBs)];
    //[self.buttonLipitHBs setText:kDiagnosisLipitHBs];
    [self.labelLipitCholesterol setText:kLocalizedString(kDiagnosisLipitCholesterol)];
    [self.textLipitCholesterol setPlaceholder:kLocalizedString(kDiagnosisLipitCholesterolValue)];
    [self.labelLipitNeutral setText:kLocalizedString(kDiagnosisLipitNeutral)];
    [self.textLipitNeutral setPlaceholder:kLocalizedString(kDiagnosisLipitNeutralValue)];
    [self.labelLipitLDL setText:kLocalizedString(kDiagnosisLipitLDL)];
    [self.textLipitLDL setPlaceholder:kLocalizedString(kDiagnosisLipitLDLValue)];
    [self.labelLipitHDL setText:kLocalizedString(kDiagnosisLipitHDL)];
    [self.textLipitHDL setPlaceholder:kLocalizedString(kDiagnosisLipitHDLValue)];
    [self.labelLipitFerritin setText:kLocalizedString(kDiagnosisLipitFerritin)];
    [self.textLipitFerritin setPlaceholder:kLocalizedString(kDiagnosisLipitFerritinValue)];
    
    
    // ---------------- Group Pancreatic -------------
    UIButton *headerPan = [self createButtonHeaderWithTitle:kLocalizedString(kTitleDiagnosisGroupPancreatic)];
    [self.viewAccordion addHeader:headerPan withView:self.viewGroupPancreatic];
    
    [self.labelPanSerum setText:kLocalizedString(kDiagnosisPanSerum)];
    [self.textPanSerum setPlaceholder:kLocalizedString(kDiagnosisPanSerumValue)];
    [self.labelPanUrine setText:kLocalizedString(kDiagnosisPanUrine)];
    [self.textPanUrine setPlaceholder:kLocalizedString(kDiagnosisPanUrineValue)];
    
    
    // ----------------- Group Renal -----------------
    UIButton *headerRenal = [self createButtonHeaderWithTitle:kLocalizedString(kTitleDiagnosisGroupRenal)];
    [self.viewAccordion addHeader:headerRenal withView:self.viewGroupRenal];
    
    [self.labelRenalUric setText:kLocalizedString(kDiagnosisRenalUric)];
    [self.textRenalUric setPlaceholder:kLocalizedString(kDiagnosisRenalUricValue)];
    [self.labelRenalUricNitro setText:kLocalizedString(kDiagnosisRenalUricNitro)];
    [self.textRenalUricNitro setPlaceholder:kLocalizedString(kDiagnosisRenalUricNitroValue)];
    [self.labelRenalCREA setText:kLocalizedString(kDiagnosisRenalCREA)];
    [self.textRenalCREA setPlaceholder:kLocalizedString(kDiagnosisRenalCREAValue)];
    
    
    // ------------------ Group Urinalysis -------------------
    UIButton *headerUri = [self createButtonHeaderWithTitle:kLocalizedString(kTitleDiagnosisGroupUrinalysis)];
    [self.viewAccordion addHeader:headerUri withView:self.viewGroupUrialysis];
    
    [self.labelUriProtein setText:kLocalizedString(kDiagnosisUriProtein)];
    //[self.buttonUriProtein setText:kLocalizedString(kDiagnosisUriProtein)];
    [self.labelUriSugar setText:kLocalizedString(kDiagnosisUriSugar)];
    //[self.buttonUriSugar setText:kLocalizedString(kDiagnosisUriSugar)];
    [self.labelUriUrobilinogen setText:kLocalizedString(kDiagnosisUriUrobilinogen)];
    //[self.buttonUriUrobilinogen setText:kLocalizedString(kDiagnosisUriUrobilinogen)];
    [self.labelUriOccultBlood setText:kLocalizedString(kDiagnosisUriOccultBlood)];
    //[self.buttonUriOccultBlood setText:kLocalizedString(kDiagnosisUriOccultBlood)];
    
}

#pragma mark - table delegate
//- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section{
//    return ((DiagnosisGroup*)self.arrayInfo[section]).title;
//}
//
//- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView{
//    return self.arrayInfo.count;
//}
//
//- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
//    return ((DiagnosisGroup*)self.arrayInfo[section]).arrayField.count;
//}
//
//- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath{
//    return 30 + 15 + 5 + 5;
//}
//
//- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath{
//    static NSString *kCellText = @"DianosisFieldText";
//    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:kCellText];
//    if (!cell) {
//        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:kCellText];
//    }
//    DiagnosisField *field = ((DiagnosisGroup*)self.arrayInfo[indexPath.section]).arrayField[indexPath.row];
//    cell.textLabel.text = field.title;
//    
//    return cell;
//}














@end
