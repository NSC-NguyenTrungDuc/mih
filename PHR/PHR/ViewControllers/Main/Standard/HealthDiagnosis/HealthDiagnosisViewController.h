//
//  HealthDiagnosisViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 10/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "AccordionView.h"

@interface HealthDiagnosisViewController : Base2ViewController <AccordionViewDelegate, UITextFieldDelegate>{
    
}
@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (strong, nonatomic) AccordionView *viewAccordion;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;

// --- Group 1 Blood ----
@property (strong, nonatomic) IBOutlet UIView *viewGroupBlood;
@property (weak, nonatomic) IBOutlet UILabel *labelBloodWBC;
@property (weak, nonatomic) IBOutlet PHRTextField *textBloodWBCValue;
@property (weak, nonatomic) IBOutlet UILabel *labelBloodRBC;
@property (weak, nonatomic) IBOutlet PHRTextField *textBloodRBCValue;
@property (weak, nonatomic) IBOutlet UILabel *labelBloodHb;
@property (weak, nonatomic) IBOutlet PHRTextField *textBloodHbValue;
@property (weak, nonatomic) IBOutlet UILabel *labelBloodHt;
@property (weak, nonatomic) IBOutlet PHRTextField *textBloodHtValue;


// --- Group 2 Sugar ----
@property (strong, nonatomic) IBOutlet UIView *viewGroupSugar;
@property (weak, nonatomic) IBOutlet UILabel *labelSugarFasting;
@property (weak, nonatomic) IBOutlet PHRTextField *textSugarFastingValue;
@property (weak, nonatomic) IBOutlet UILabel *labelSugarPostprandial;
@property (weak, nonatomic) IBOutlet PHRTextField *textSugarPostprandialValue;
@property (weak, nonatomic) IBOutlet UILabel *labelSugarHbA1c;
@property (weak, nonatomic) IBOutlet PHRTextField *textSugarHbA1cValue;


// --- Group 3 Lipit ----
@property (strong, nonatomic) IBOutlet UIView *viewGroupLipit;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitProtein;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitProtein;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitALB;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitALB;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitGOTAST;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitGOTAST;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitGPTALT;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitGPTALT;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitLDH;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitLDH;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitALP;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitALP;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitGTP;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitGTP;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitZZT;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitZZT;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitTBil;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitTBil;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitHBs;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *buttonLipitHBs;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitCholesterol;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitCholesterol;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitNeutral;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitNeutral;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitLDL;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitLDL;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitHDL;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitHDL;
@property (weak, nonatomic) IBOutlet UILabel *labelLipitFerritin;
@property (weak, nonatomic) IBOutlet PHRTextField *textLipitFerritin;


// --- Group 4 ----
@property (strong, nonatomic) IBOutlet UIView *viewGroupPancreatic;
@property (weak, nonatomic) IBOutlet UILabel *labelPanSerum;
@property (weak, nonatomic) IBOutlet PHRTextField *textPanSerum;
@property (weak, nonatomic) IBOutlet UILabel *labelPanUrine;
@property (weak, nonatomic) IBOutlet PHRTextField *textPanUrine;


// --- Group 5 ----
@property (strong, nonatomic) IBOutlet UIView *viewGroupRenal;
@property (weak, nonatomic) IBOutlet UILabel *labelRenalUric;
@property (weak, nonatomic) IBOutlet PHRTextField *textRenalUric;
@property (weak, nonatomic) IBOutlet UILabel *labelRenalUricNitro;
@property (weak, nonatomic) IBOutlet PHRTextField *textRenalUricNitro;
@property (weak, nonatomic) IBOutlet UILabel *labelRenalCREA;
@property (weak, nonatomic) IBOutlet PHRTextField *textRenalCREA;


// --- Group 6 ----
@property (strong, nonatomic) IBOutlet UIView *viewGroupUrialysis;
@property (weak, nonatomic) IBOutlet UILabel *labelUriProtein;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *buttonUriProtein;
@property (weak, nonatomic) IBOutlet UILabel *labelUriSugar;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *buttonUriSugar;
@property (weak, nonatomic) IBOutlet UILabel *labelUriUrobilinogen;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *buttonUriUrobilinogen;
@property (weak, nonatomic) IBOutlet UILabel *labelUriOccultBlood;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *buttonUriOccultBlood;
















@end
