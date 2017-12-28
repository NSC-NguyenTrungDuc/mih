package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import nta.mss.info.AccountInfoDto;
import nta.mss.info.UserChildDto;

/**
 * @author HoanPC
 *
 */
public interface ProfileRepositoryCustom {
	public AccountInfoDto getAccountInfoByAccountId(Long accountId);
	public List<UserChildDto> getUserchildsByAccountId(Long accountId);
	public UserChildDto getUserchildByChildId(BigInteger childId);
}
