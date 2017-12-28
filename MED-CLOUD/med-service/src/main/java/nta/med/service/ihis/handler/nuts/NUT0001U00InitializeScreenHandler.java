package nta.med.service.ihis.handler.nuts;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.nut.Nut0001Repository;
import nta.med.data.dao.medi.nut.Nut0002Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.nuts.Nut0001U00GrdNut0001ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NutsModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUT0001U00InitializeScreenHandler extends ScreenHandler<NutsServiceProto.NUT0001U00InitializeScreenRequest, NutsServiceProto.NUT0001U00InitializeScreenResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(NUT0001U00InitializeScreenHandler.class);                                    
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ocs0103Repository ocs0103Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Nut0001Repository nut0001Repository;
	@Resource
	private Nut0002Repository nut0002Repository;

	@Override
	@Transactional
	public NutsServiceProto.NUT0001U00InitializeScreenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NutsServiceProto.NUT0001U00InitializeScreenRequest request) throws Exception {
		NutsServiceProto.NUT0001U00InitializeScreenResponse.Builder response = NutsServiceProto.NUT0001U00InitializeScreenResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		// 1.
		Date date = new Date();
		response.setSysDate(date.toString());
		
		// 2.
		SimpleDateFormat dateFormat = new SimpleDateFormat(DateUtil.PATTERN_YYMMDD);
		if(StringUtils.isEmpty(request.getDoctorGwaName())){
			String gwaName = bas0260Repository.getBasLoadGwaName(request.getGwaCode(), dateFormat.format(date), hospCode, getLanguage(vertx, sessionId));
			if(!StringUtils.isEmpty(gwaName)){
				response.setGwaName(gwaName);
			}
		}
		
		// 3.
		List<Nut0001U00GrdNut0001ItemInfo> listGrdNut0001 = nut0001Repository.getNut0001U00GrdNut0001ItemInfo(hospCode, CommonUtils.parseDouble(request.getPkocskey()));
		if(!CollectionUtils.isEmpty(listGrdNut0001)){
			for(Nut0001U00GrdNut0001ItemInfo item : listGrdNut0001){
				NutsModelProto.NUT0001U00GrdNUT0001ItemInfo.Builder info = NutsModelProto.NUT0001U00GrdNUT0001ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrd001ItemInfo(info);
			}
		}
		
		// 4.
		if(CollectionUtils.isEmpty(listGrdNut0001)){
			String seq = commonRepository.getNextVal("NUT0001_SEQ");
			if(!StringUtils.isEmpty(seq)){
				response.setSeq(seq);
			}
			String hangMogName = ocs0103Repository.getHIGetHangmogName(hospCode, request.getHangmogCode());
			if(!StringUtils.isEmpty(hangMogName)){
				response.setHangmogName(hangMogName);
			}
		}
		
		
		//5.
		String insteadOrder = ocs1003Repository.callFnOcsInsteadModifiedCheck(hospCode, CommonUtils.parseInteger(request.getPkocskey()), "CK", request.getInOutGubun());
		if(!StringUtils.isEmpty(insteadOrder)){
			if(insteadOrder.equals("1") ){
				response.setIsPossibleInsteadOrder(true);
			}else{
				response.setIsPossibleInsteadOrder(false);
			}
		}
		return response.build();
	}                                                                                                            
}