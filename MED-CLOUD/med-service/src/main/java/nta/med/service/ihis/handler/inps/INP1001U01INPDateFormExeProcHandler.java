package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01INPDateFormExeProcRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01INPDateFormExeProcResponse;

@Service                                                                                                          
@Scope("prototype")
public class INP1001U01INPDateFormExeProcHandler extends
		ScreenHandler<InpsServiceProto.INP1001U01INPDateFormExeProcRequest, InpsServiceProto.INP1001U01INPDateFormExeProcResponse> {

	private static final Log LOGGER = LogFactory.getLog(INP1001U01INPDateFormExeProcHandler.class);   
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(rollbackFor = Exception.class)
	public INP1001U01INPDateFormExeProcResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01INPDateFormExeProcRequest request) throws Exception {
		
		InpsServiceProto.INP1001U01INPDateFormExeProcResponse.Builder response = InpsServiceProto.INP1001U01INPDateFormExeProcResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<CommonModelProto.DataStringListItemInfo> listParam = request.getInpListList();
		if(CollectionUtils.isEmpty(listParam) || listParam.size() < 9){
			LOGGER.info("Input params are not valid.");
			return response.build();
		}
		
		CommonProcResultInfo procResult = inp1001Repository.callPrInpUpdateIpwonDate(hospCode
				, listParam.get(0).getDataValue()
				, CommonUtils.parseDouble(listParam.get(1).getDataValue())
				, DateUtil.toDate(listParam.get(2).getDataValue(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(listParam.get(3).getDataValue(), DateUtil.PATTERN_YYMMDD)
				, listParam.get(4).getDataValue()
				, listParam.get(5).getDataValue()
				, listParam.get(6).getDataValue()
				, listParam.get(7).getDataValue());
		
		if(procResult == null){
			LOGGER.info("Proc result is null.");
			return response.build();
		}
		
		CommonModelProto.DataStringListItemInfo.Builder errInfo = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(procResult.getStrResult1());
		CommonModelProto.DataStringListItemInfo.Builder msg = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(procResult.getStrResult2());
		response.addOutList(errInfo);
		response.addOutList(msg);
		
		return response.build();
	}

}
