package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inp.Inp1003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.inps.INP1001Q00grdINP1001Info;
import nta.med.data.model.ihis.inps.INP1003U00SaveLayoutChkBunhoInfo;
import nta.med.data.model.ihis.nuro.OUT0101Q01GrdPatientListInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00SaveLayoutHandler extends ScreenHandler<InpsServiceProto.INP1003U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(true);
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<InpsModelProto.INP1003U00grdInpReserInfo> listGroupItem = request.getGrdSaveList();
		if(CollectionUtils.isEmpty(listGroupItem)) {
			response.setResult(false);
			return response.build();
		}
		
		for (InpsModelProto.INP1003U00grdInpReserInfo item : listGroupItem) {
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				if (checkValid(item, "I", vertx, sessionId, response, language)) {
					// get sequence
					String seqInp1003 = commonRepository.getNextVal("INP1003_SEQ");
					String seqInp1001 = commonRepository.getNextVal("INP1001_SEQ");
					Double pkInp1003 = CommonUtils.parseDouble(seqInp1003);
					Double reserFkinp1001 = CommonUtils.parseDouble(seqInp1001);
					
					// insert
					Inp1003 inp1003 = new Inp1003();
					inp1003.setSysDate(new Date());
					inp1003.setSysId(item.getUserId());
					inp1003.setUpdDate(new Date());
					
					inp1003.setPkinp1003(pkInp1003);
					inp1003.setJunpyoDate(DateUtil.toDate(DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
					inp1003.setBunho(item.getBunho());
					
					inp1003.setTel1(item.getTel1());
					inp1003.setTel2(item.getTel2());
					inp1003.setReserDate(DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD));
					
					inp1003.setGwa(item.getGwa());
					inp1003.setDoctor(item.getDoctor());
					inp1003.setHoCode(item.getHoCode());
					
					inp1003.setReserEndType(item.getReserEndType());
					inp1003.setRemark(item.getRemark());
					inp1003.setSusulReserYn(item.getSusulReserYn());
					
					inp1003.setIpwonRtn2(item.getIpwonRtn2());
					inp1003.setHoDong(item.getHoDong());
					inp1003.setBedNo(item.getBedNo());
					
					inp1003.setIpwonMokjuk(item.getIpwonMokjuk());
					inp1003.setIpwonsiOrderYn(item.getIpwonsiOrderYn());
					inp1003.setJisiDoctor(item.getJisiDoctor());
					
					inp1003.setSangBigo(item.getSangBigo());
					inp1003.setSogyeYn(item.getSogyeYn());
					inp1003.setHopeRoom(item.getHopeRoom());
					
					inp1003.setHospCode(hospCode);
					inp1003.setUpdId(item.getUserId());
					inp1003.setReserFkinp1001(reserFkinp1001);
					
					inp1003Repository.save(inp1003);
					if(inp1003 == null || inp1003.getId() == null){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if (checkValid(item, "U", vertx, sessionId, response, language)) {
					if(inp1003Repository.updateInp1001(	item.getUserId(), item.getJunpyoDate(), item.getTel1(), item.getTel2(), item.getReserDate(),
							item.getGwa(), item.getDoctor(), item.getHoCode(), item.getReserEndType(), item.getRemark(),
							item.getSusulReserYn(), item.getIpwonRtn2(), item.getHoDong(), item.getBedNo(), item.getIpwonMokjuk(),
							item.getJisiDoctor(), item.getSangBigo(), item.getSogyeYn(), item.getHopeRoom(), hospCode, Double.parseDouble(item.getPkinp1003())) <= 0) {
						response.setResult(false);
						return response.build();
					}
				}
			} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if (StringUtils.isEmpty(item.getBunho())) {
					response.setMsg("001");
					response.setResult(false);
					return response.build();
				}
				
				if(inp1003Repository.deleteInp1003(hospCode, Double.parseDouble(item.getPkinp1003())) <= 0) {
					response.setResult(false);
					return response.build();
				}
				
			}
		}
		
		return response.build();
	}
	
	private boolean checkValid(InpsModelProto.INP1003U00grdInpReserInfo info, String chkFlag, Vertx vertx, String sessionId, SystemServiceProto.UpdateResponse.Builder response, String language) {
		if(StringUtils.isEmpty(info.getBunho())) {
			response.setMsg("001");
			response.setResult(false);
			return false;
		}

		String hospCode = getHospitalCode(vertx, sessionId);
		if ("I".equals(chkFlag)) {
			if (inp1003ChkBunho(info.getBunho(), vertx, sessionId, response, language) != 0) {
				return false;
			}

			if (inp1003CheckJaewon(hospCode, info.getBunho(), info.getReserDate()) == 0) {
				response.setMsg("004");
				response.setResult(false);
				return false;
			}
		}

		
		if ("I".equals(chkFlag)) {
			if ("Y".equals(inp1003Repository.getINP1003U00YByReserDate(hospCode, info.getBunho(), info.getReserDate()))) {
                response.setMsg("005");
				response.setResult(false);
                return false;
			}
		}
		if ("U".equals(chkFlag)) {
			if ("Y".equals(inp1003Repository.getINP1003U00YByReserEndType(hospCode, info.getBunho(), info.getReserDate(), CommonUtils.parseDouble(info.getPkinp1003())))) {
                response.setMsg("005");
				response.setResult(false);
                return false;
			}
			
		}		
		return true;
	}

	public int inp1003ChkBunho(String bunho, Vertx vertx, String sessionId, SystemServiceProto.UpdateResponse.Builder response, String language) {
		int rtnService = 0;	

		List<INP1003U00SaveLayoutChkBunhoInfo> listInfo = out0101Repository.getOut0101U00ByBunho(getHospitalCode(vertx, sessionId), language, bunho);
		if (listInfo.size() == 0) {
			response.setMsg("001");
			response.setResult(false);
			rtnService = 1;
		} else {
			if ("Y".equals(listInfo.get(0).getDeleteYn())) {
				response.setMsg("002");
				response.setResult(false);
				rtnService = 1;
			}
			if ("Y".equals(listInfo.get(0).getJubsuBreak())) {
				// format this message: "key 007"
				response.setMsg(listInfo.get(0).getCodeName() + " 007");
				response.setResult(false);
				rtnService = 1;
			}
		}
		return rtnService;
	}

	public  int inp1003CheckJaewon(String hospCode, String bunho, String ipwonDate) {
		int rtnService = 0;

		List<INP1001Q00grdINP1001Info> listInfo = inp1001Repository.getINP1001U00Pkinp1001JaewonFlagInfo(hospCode, bunho, ipwonDate);
	
		if (listInfo.size() == 0) {
			rtnService = 1;
		}
	
		return rtnService;
	}
	
}
