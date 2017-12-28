package nta.med.service.ihis.handler.schs;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.ModuleType;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SCH0201Q12GrdListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12UpdateReserDataRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12UpdateReserDataResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class SCH0201Q12UpdateReserDataHandler
	extends ScreenHandler<SchsServiceProto.SCH0201Q12UpdateReserDataRequest, SchsServiceProto.SCH0201Q12UpdateReserDataResponse> {
	private static final Log LOG =  LogFactory.getLog(SCH0201Q12UpdateReserDataHandler.class);
	@Resource
	private Inj1002Repository inj1002Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	public SCH0201Q12UpdateReserDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SCH0201Q12UpdateReserDataRequest request) throws Exception {
		SchsServiceProto.SCH0201Q12UpdateReserDataResponse.Builder response = SchsServiceProto.SCH0201Q12UpdateReserDataResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		// all action not rollback
		Date reserDate = DateUtil.toDate(request.getReserDate(),DateUtil.PATTERN_YYMMDD);
		response.setReserResult(false);
		List<SchsModelProto.SCH0201Q12UpdateReserData> listData = request.getUpdateDataList();
		if (ModuleType.INJ.getValue().equalsIgnoreCase(request.getGubun())) {
			LOG.info("[START] CASE INJ");
			List<Double> pkinj1002List = new ArrayList<Double>();
			if (!CollectionUtils.isEmpty(listData)) {
				for (SchsModelProto.SCH0201Q12UpdateReserData item : listData) {
					if (!StringUtils.isEmpty(item)) {
						pkinj1002List.add(CommonUtils.parseDouble(item.getPkinj1002()));
					}
				}
				for (SchsModelProto.SCH0201Q12UpdateReserData item : listData) {
					List<Double> list = inj1002Repository.getFkocs1003(hospCode, item.getPkinj1002());
					if (!CollectionUtils.isEmpty(list)) {
						Integer rsOcs1003 = ocs1003Repository.updatePrOcsUpdateHopeDateCaseOut(hospCode, reserDate , list);
						LOG.info("updatePrOcsUpdateHopeDateCaseOut  rsOcs1003=" + rsOcs1003);
					}
				}
			}
		response.setReserResult(true);
		} else {
			LOG.info("[START] CASE OTHER CASE");
			boolean result = updateReserDataNotInj(request.getIudGubun(), reserDate, listData, hospCode);
			if (!result) response.setMsg("X"); 
			response.setReserResult(result);
		}
		List<SCH0201Q12GrdListItemInfo> listResult = sch0201Repository.getSCH0201Q12GrdListItemInfo(hospCode,
	    		 request.getBunho(),request.getStatFlg(),request.getNaewonDate(),request.getGwa(),request.getDoctor(),request.getReserGubun(), getLanguage(vertx, sessionId));
	     if(listResult!= null && !listResult.isEmpty()){
	    	 for(SCH0201Q12GrdListItemInfo item : listResult){
	    		 SchsModelProto.SCH0201Q12GrdListItemInfo.Builder info = SchsModelProto.SCH0201Q12GrdListItemInfo.newBuilder();
	    		 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		 response.addGrdListItem(info);
	    	 }
	     }
	     
	     response.setKensaResult(false);
	     if(out1001Repository.updateSchsSCH0201Q12UpdateKensaYn(hospCode, CommonUtils.parseDouble(request.getPkout1001())) >0 ) {
	    	 response.setKensaResult(true);
	     }
	     return response.build();
	}
	private boolean updateReserDataNotInj(String iudGubun, Date reserDate, List<SchsModelProto.SCH0201Q12UpdateReserData> listData, String hospCode) {
		if (!CollectionUtils.isEmpty(listData)) {
			for (SchsModelProto.SCH0201Q12UpdateReserData item : listData) {
				String fksch0201 = null;
				if(!StringUtils.isEmpty(item.getFksch0201())) {
					fksch0201 = item.getFksch0201().substring(0, item.getFksch0201().indexOf("."));
				}
				String result = sch0201Repository.callPrSchSch0210Iud(hospCode, iudGubun, fksch0201, reserDate ,item.getReserTime(),item.getPkinj1002(),"");
				if (result != null) {
					if("X".equalsIgnoreCase(result)) {
						return false;
					}
				}
			}
		}
		return true;
	}
}
