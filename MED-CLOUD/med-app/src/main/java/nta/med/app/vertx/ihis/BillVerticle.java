package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.bill.BIL0102U00PrintTemplateHandler;
import nta.med.service.ihis.handler.bill.BIL2016R01CboAllHandler;
import nta.med.service.ihis.handler.bill.BIL2016R01CboExeDeptHandler;
import nta.med.service.ihis.handler.bill.BIL2016R01FbxExeDoctorHandler;
import nta.med.service.ihis.handler.bill.BIL2016R01FbxPersonHandler;
import nta.med.service.ihis.handler.bill.BIL2016R01GrdReportHandler;
import nta.med.service.ihis.handler.bill.BIL2016U00DetailServiceHandler;
import nta.med.service.ihis.handler.bill.BIL2016U00GrdMasterHandler;
import nta.med.service.ihis.handler.bill.BIL2016U00SaveGrdMasterHandler;
import nta.med.service.ihis.handler.bill.BIL2016U01LoadPatientHandler;
import nta.med.service.ihis.handler.bill.CheckLasteInvoiceBIL2016U02Handler;
import nta.med.service.ihis.handler.bill.GetDataComboInvoiceBIL2016U02Handler;
import nta.med.service.ihis.handler.bill.LoadComboBIL2016U02Handler;
import nta.med.service.ihis.handler.bill.LoadGridBIL2016U02Handler;
import nta.med.service.ihis.handler.bill.LoadGridPayHistoryBIL2016U02Handler;
import nta.med.service.ihis.handler.bill.BIL0102U00DataReportHandler;
import nta.med.service.ihis.handler.bill.SaveBIL2016U02Handler;
import nta.med.service.ihis.proto.BillServiceProto;

/**
 * @author DEV-TiepNM
 */
public class BillVerticle extends AbstractVerticle {

    public BillVerticle() {
        super(BillServiceProto.class, BillServiceProto.getDescriptor());
    }
    @Override
    protected void doStart() throws Exception {
    	registerHandler(BillServiceProto.BIL2016U01LoadPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL2016U01LoadPatientHandler.class));
    	registerHandler(BillServiceProto.LoadComboBIL2016U02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadComboBIL2016U02Handler.class));
    	registerHandler(BillServiceProto.SaveBIL2016U02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SaveBIL2016U02Handler.class));
    	registerHandler(BillServiceProto.LoadGridBIL2016U02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadGridBIL2016U02Handler.class));
    	registerHandler(BillServiceProto.GetDataComboInvoiceBIL2016U02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetDataComboInvoiceBIL2016U02Handler.class));
    	registerHandler(BillServiceProto.LoadGridPayHistoryBIL2016U02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadGridPayHistoryBIL2016U02Handler.class));
    	registerHandler(BillServiceProto.CheckLasteInvoiceBIL2016U02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckLasteInvoiceBIL2016U02Handler.class));
    	registerHandler(BillServiceProto.BIL0102U00DataReportRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL0102U00DataReportHandler.class));
    	
    	// [START] [BIL2016R01]
    	registerHandler(BillServiceProto.BIL2016R01CboAllRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL2016R01CboAllHandler.class));
    	registerHandler(BillServiceProto.BIL2016R01FbxPersonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL2016R01FbxPersonHandler.class));
    	registerHandler(BillServiceProto.BIL2016R01GrdReportRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL2016R01GrdReportHandler.class));
    	// [END] [BIL2016R01]

        registerHandler(BillServiceProto.BIL2016U00GrdMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL2016U00GrdMasterHandler.class));
        registerHandler(BillServiceProto.BIL2016U00DetailServiceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL2016U00DetailServiceHandler.class));
        registerHandler(BillServiceProto.BIL2016U00SaveGrdMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL2016U00SaveGrdMasterHandler.class));
        
        registerHandler(BillServiceProto.BIL2016R01CboExeDeptRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL2016R01CboExeDeptHandler.class));
        registerHandler(BillServiceProto.BIL2016R01FbxExeDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL2016R01FbxExeDoctorHandler.class));
        registerHandler(BillServiceProto.BIL0102U00PrintTemplateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BIL0102U00PrintTemplateHandler.class));
    }

    @Override
    protected void doStop() throws Exception {

    }
}
