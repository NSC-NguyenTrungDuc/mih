package nta.med.service.ihis.handler.inps;

import java.util.Date;
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

import nta.med.core.domain.inp.Inp1001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.InpsModelProto.INP1001U01EtcIpwongrdHistoryInfo;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01EtcIpwonSaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class INP1001U01EtcIpwonSaveLayoutHandler extends ScreenHandler<InpsServiceProto.INP1001U01EtcIpwonSaveLayoutRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOG = LogFactory.getLog(INP1001U01EtcIpwonSaveLayoutHandler.class);
	@Resource
	private Inp1001Repository inp1001Repository;
	@Resource                                                                                                       
	private CommonRepository commonRepository;  
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01EtcIpwonSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<INP1001U01EtcIpwongrdHistoryInfo> list = request.getGrdSaveList();
		if (CollectionUtils.isEmpty(list)) {
			LOG.info("List null !!!!!!");
			response.setResult(false);
			return response.build();
		}
		
		String hospCode = getHospitalCode(vertx, sessionId);
		for (INP1001U01EtcIpwongrdHistoryInfo item : list) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
				String nextSeqVal =  commonRepository.getNextValByHospCode(hospCode, "INP1001_SEQ");
				if (StringUtils.isEmpty(nextSeqVal)) {
					LOG.info("Next value INP1001_SEQ null !!!!!!");
					response.setResult(false);
					return response.build();
				}
				if (insertInp1001(request.getUserId(), hospCode, nextSeqVal, item, request.getHoDong1(), request.getHoCode1(), request.getDoctor(), request.getBunho()) > 0) {
					LOG.info("ADDED success !!!!!!");
				}
				else {
					response.setResult(false);
					LOG.info("ADDED fail !!!!!!");
					return response.build();
				}
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				if (updateInp1001(request.getUserId(), hospCode, item, request.getDoctor()) > 0) {
					LOG.info("MODIFIED success !!!!!!");
				} else {
					response.setResult(false);
					LOG.info("MODIFIED fail !!!!!!");
					return response.build();
				}
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
				if (deleteInp1001(hospCode, request.getUserId(), item.getPkinp1001()) > 0) {
					LOG.info("DELETED success !!!!!!");
				} else {
					response.setResult(false);
					LOG.info("DELETED fail !!!!!!");
					return response.build();
				}
			} else {
				response.setResult(false);
				LOG.info("Row State Null !!!!!!");
				return response.build();
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	private Integer insertInp1001(String userId, String hospCode, String nextSeqVal, INP1001U01EtcIpwongrdHistoryInfo item, String hoDong1, String hoCode1, String doctor, String bunho) {
		Inp1001 inp1001 = new Inp1001();
		inp1001.setSysDate(new Date());
		inp1001.setSysId(userId);
		inp1001.setUpdDate(new Date());
		inp1001.setUpdId(userId);
		inp1001.setHospCode(hospCode);
		inp1001.setPkinp1001(CommonUtils.parseDouble(nextSeqVal));
		inp1001.setBunho(bunho); 
		inp1001.setIpwonDate(DateUtil.toDate(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setIpwonType(item.getIpwonType());
		inp1001.setIpwonTime("1200");
		inp1001.setGwa(item.getGwa());
		inp1001.setDoctor(doctor);
		inp1001.setResident(doctor);
		inp1001.setHoCode1(hoCode1);
		inp1001.setHoDong1(hoDong1);
		inp1001.setFkInpKey(CommonUtils.parseDouble(nextSeqVal));
		inp1001.setToiwonDate(DateUtil.toDate(item.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1001.setJaewonFlag("N");
		Inp1001 inp1001Check = inp1001Repository.save(inp1001);
		if (inp1001Check != null  && inp1001Check.getId() != null)
			return 1;
		return -1;
	}
	
	private Integer updateInp1001(String userId, String hospCode, INP1001U01EtcIpwongrdHistoryInfo item, String doctor) {
		if (inp1001Repository.updateINP1001U01EtcIpwonExecute(hospCode, userId, CommonUtils.parseDouble(item.getPkinp1001()), item.getGwa(), doctor, DateUtil.toDate(item.getToiwonDate(), DateUtil.PATTERN_YYMMDD)) > 0)
			return 1;
		return -1;
	}
	
	private Integer deleteInp1001(String hospCode, String userId, String pkinp1001) {
		if (inp1001Repository.deleteINP1001U01EtcIpwonExecute(hospCode, userId, CommonUtils.parseDouble(pkinp1001)) > 0)
			return 1;
		return -1;
	}
}

