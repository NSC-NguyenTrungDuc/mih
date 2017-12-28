package nta.med.service.ihis.handler.bill;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.bil.Bil0001Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.bill.BIL2016U00ServiceInfo;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class BIL2016U00GrdMasterHandler extends
		ScreenHandler<BillServiceProto.BIL2016U00GrdMasterRequest, BillServiceProto.BIL2016U00GrdMasterResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(BIL2016U00GrdMasterHandler.class);
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	@Resource
	private Adm0000Repository adm0000Repository;
	@Resource
	private Bil0001Repository bil0001Repository;

	@Override
	@Transactional(readOnly = true)
	public BillServiceProto.BIL2016U00GrdMasterResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BillServiceProto.BIL2016U00GrdMasterRequest request) throws Exception {

		Integer startNum = null;
		String offset = request.getOffset();
		if (!StringUtils.isEmpty(request.getPageNumber())) {
			startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		}

		BillServiceProto.BIL2016U00GrdMasterResponse.Builder response = BillServiceProto.BIL2016U00GrdMasterResponse.newBuilder();
		String hangmogNameInx =  request.getHangmogNameInx();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<BIL2016U00ServiceInfo> bil2016U00ServiceInfos = null;
		if(!StringUtils.isEmpty(hangmogNameInx) && Language.JAPANESE.toString().equalsIgnoreCase(getLanguage(vertx, sessionId)))
		{
			hangmogNameInx = adm0000Repository.callFnAdmConvertKanaFull(hospCode, hangmogNameInx);
		}
		if("ADMISSION_FEE".equalsIgnoreCase(request.getOrderGubun())){
			bil2016U00ServiceInfos = bil0001Repository.getBIL2016U00ServiceInfoCaseVisitFee(hospCode, language, hangmogNameInx, startNum, CommonUtils.parseInteger(offset));
		} else if("%".equalsIgnoreCase(request.getOrderGubun())) {
			bil2016U00ServiceInfos = bil0001Repository.getBIL2016U00ServiceInfoCaseSearchAll(hospCode, hangmogNameInx, request.getOrderGubun(),
					request.getCodeType(), language, startNum, CommonUtils.parseInteger(offset));
		} else{
			bil2016U00ServiceInfos = ocs0103Repository.getBIL2016U00ServiceInfo(
					hospCode, hangmogNameInx, request.getOrderGubun(),
					request.getCodeType(), language, startNum, CommonUtils.parseInteger(offset));
		}
		if (!CollectionUtils.isEmpty(bil2016U00ServiceInfos)) {
			//DecimalFormat df = new DecimalFormat("###.###");
			for (BIL2016U00ServiceInfo item : bil2016U00ServiceInfos) {
				BillModelProto.BIL2016U00ServiceInfo.Builder info = BillModelProto.BIL2016U00ServiceInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPrice1() != null) {
					info.setPrice1(String.format("%.0f",item.getPrice1()));
				}
//				if(item.getPrice1() != null) info.setPrice1(df.format(item.getPrice1()));
//				if(item.getPrice2() != null) info.setPrice2(df.format(item.getPrice2()));
//				if(item.getPrice3() != null) info.setPrice3(df.format(item.getPrice3()));
				
				if (item.getPrice2() != null) {
					info.setPrice2(String.format("%.0f",item.getPrice2()));
				}
				if (item.getPrice3() != null) {
					info.setPrice3(String.format("%.0f",item.getPrice3()));
				}
				response.addListInfo(info);
			}
		}else{
			LOGGER.info("BIL2016U00GrdMasterHandler handler not found list of BIL2016U00ServiceInfo");
		}
		return response.build();
	}

}
