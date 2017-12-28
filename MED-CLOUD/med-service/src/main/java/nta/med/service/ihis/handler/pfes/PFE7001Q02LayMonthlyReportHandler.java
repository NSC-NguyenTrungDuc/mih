package nta.med.service.ihis.handler.pfes;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.pfes.PFE7001Q02LayMonthlyReportInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesModelProto;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE7001Q02LayMonthlyReportRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE7001Q02LayMonthlyReportResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE7001Q02LayMonthlyReportHandler
	extends ScreenHandler <PfesServiceProto.PFE7001Q02LayMonthlyReportRequest, PfesServiceProto.PFE7001Q02LayMonthlyReportResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE7001Q02LayMonthlyReportResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PFE7001Q02LayMonthlyReportRequest request) throws Exception {                                                                   
      	   	PfesServiceProto.PFE7001Q02LayMonthlyReportResponse.Builder response = PfesServiceProto.PFE7001Q02LayMonthlyReportResponse.newBuilder();                      
        List<PFE7001Q02LayMonthlyReportInfo> listObject = ocs0103Repository.getPFE7001Q02LayMonthlyReportInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId)
        		, request.getFromDate(), request.getToDate(), request.getIoGubun(), request.getPartCode());
            if(!CollectionUtils.isEmpty(listObject)) {
            	for(PFE7001Q02LayMonthlyReportInfo item : listObject) {
            		PfesModelProto.PFE7001Q02LayMonthlyReportInfo.Builder info = PfesModelProto.PFE7001Q02LayMonthlyReportInfo.newBuilder();
            		if (!StringUtils.isEmpty(item.getYyyymm())) {
            			info.setYyyymm(item.getYyyymm());
            		}
            		if (!StringUtils.isEmpty(item.getHangmogCode())) {
            			info.setHangmogCode(item.getHangmogCode());
            		}
            		if (!StringUtils.isEmpty(item.getGumsaName())) {
            			info.setGumsaName(item.getGumsaName());
            		}
            		if (item.getD01() != null) {
            			info.setD01(item.getD01().toString());
            		}
            		if (item.getD02() != null) {
            			info.setD02(item.getD02().toString());
            		}
            		if (item.getD03() != null) {
            			info.setD03(item.getD03().toString());
            		}
            		if (item.getD04() != null) {
            			info.setD04(item.getD04().toString());
            		}
            		if (item.getD05() != null) {
            			info.setD05(item.getD05().toString());
            		}
            		if (item.getD06() != null) {
            			info.setD06(item.getD06().toString());
            		}
            		if (item.getD07() != null) {
            			info.setD07(item.getD07().toString());
            		}
            		if (item.getD08() != null) {
            			info.setD08(item.getD08().toString());
            		}
            		if (item.getD09() != null) {
            			info.setD09(item.getD09().toString());
            		}
            		if (item.getD10() != null) {
            			info.setD10(item.getD10().toString());
            		}
            		if (item.getD11() != null) {
            			info.setD11(item.getD11().toString());
            		}
            		if (item.getD12() != null) {
            			info.setD12(item.getD12().toString());
            		}
            		if (item.getD13() != null) {
            			info.setD13(item.getD13().toString());
            		}
            		if (item.getD14() != null) {
            			info.setD14(item.getD14().toString());
            		}
            		if (item.getD15() != null) {
            			info.setD15(item.getD15().toString());
            		}
            		if (item.getD16() != null) {
            			info.setD16(item.getD16().toString());
            		}
            		if (item.getD17() != null) {
            			info.setD17(item.getD17().toString());
            		}
            		if (item.getD18() != null) {
            			info.setD18(item.getD18().toString());
            		}
            		if (item.getD19() != null) {
            			info.setD19(item.getD19().toString());
            		}
            		if (item.getD20() != null) {
            			info.setD20(item.getD20().toString());
            		}
            		if (item.getD21() != null) {
            			info.setD21(item.getD21().toString());
            		}
            		if (item.getD22() != null) {
            			info.setD22(item.getD22().toString());
            		}
            		if (item.getD23() != null) {
            			info.setD23(item.getD23().toString());
            		}
            		if (item.getD24() != null) {
            			info.setD24(item.getD24().toString());
            		}
            		if (item.getD25() != null) {
            			info.setD25(item.getD25().toString());
            		}
            		if (item.getD26() != null) {
            			info.setD26(item.getD26().toString());
            		}
            		if (item.getD27() != null) {
            			info.setD27(item.getD27().toString());
            		}
            		if (item.getD28() != null) {
            			info.setD28(item.getD28().toString());
            		}
            		if (item.getD29() != null) {
            			info.setD29(item.getD29().toString());
            		}
            		if (item.getD30() != null) {
            			info.setD30(item.getD30().toString());
            		}
            		if (item.getD31() != null) {
            			info.setD31(item.getD31().toString());
            		}
            		if (item.getTotal() != null) {
            			info.setTotal(item.getTotal().toString());
            		}
            		response.addMonthlyReportItem(info);
            	}
            }
            return response.build();
	}
}